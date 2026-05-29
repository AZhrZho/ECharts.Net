using Microsoft.Web.WebView2.Core;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ECharts.Net;

public class WebView2Proxy : IWebViewProxy
{
    static WebView2Proxy()
    {
        WebViewProxy.BridgedObjectHost = "window.chrome.webview.hostObjects.sync";
    }

    private static readonly Lazy<string> _scriptTempDir = new(() =>
    {
        var dir = Path.Combine(Path.GetTempPath(), "ECharts.Net");
        Directory.CreateDirectory(dir);
        File.WriteAllText(Path.Combine(dir, ScriptFileName), Config.EChartsEngineScript);
        return dir;
    });

    private const string VirtualHostName = "echarts.local";
    private const string ScriptFileName = "echarts.min.js";

    public WebView2Proxy(CoreWebView2 webView2)
    {
        coreWebView2 = webView2;
    }

    private readonly CoreWebView2 coreWebView2;

    /// <summary>
    /// 自定义容器 HTML，设置后使用该 HTML 替代默认模板，需自行引入 echarts 并创建图表容器
    /// </summary>
    public string? ContainerHtml { get; set; }

    /// <summary>
    /// 自定义容器中图表 div 的元素 ID，默认为 "root"
    /// </summary>
    public string? ContainerElementId { get; set; }

    public Task<string> InvokeScriptAsync(string script)
    {
        return coreWebView2.ExecuteScriptAsync(script);
    }

    public async Task InitializeEchartsEngineAsync(bool isDarkTheme = false)
    {
        var tcs = new TaskCompletionSource<bool>();

        coreWebView2.NavigationCompleted += NavigationCompleteHandler;
        // 禁用 DevTools，移除右键菜单中的"检查"选项
        coreWebView2.Settings.AreDevToolsEnabled = false;

        if (ContainerHtml != null)
        {
            // 自定义模式：直接加载用户提供的 HTML，随后手动注入 echarts 脚本
            coreWebView2.NavigateToString(ContainerHtml);
        }
        else
        {
            // 默认模式：通过虚拟主机映射加载 echarts.js，避免内联大体积脚本
            coreWebView2.SetVirtualHostNameToFolderMapping(
                VirtualHostName, _scriptTempDir.Value,
                CoreWebView2HostResourceAccessKind.Allow);
            coreWebView2.NavigateToString(BuildContainerHtml(isDarkTheme));
        }

        await tcs.Task;

        if (ContainerHtml != null)
        {
            await coreWebView2.ExecuteScriptAsync(Config.EChartsEngineScript);
            await coreWebView2.ExecuteScriptAsync(
                $"const chart=echarts.init(document.getElementById('{ContainerElementId ?? "root"}'))");
        }

        void NavigationCompleteHandler(object? sender, CoreWebView2NavigationCompletedEventArgs _)
        {
            coreWebView2.NavigationCompleted -= NavigationCompleteHandler;
            tcs.SetResult(true);
        }
    }

    private static string BuildContainerHtml(bool isDarkTheme = false)
    {
        var themeArg = isDarkTheme ? ", 'dark'" : "";
        return $$"""
            <!DOCTYPE html>
            <html>
            <head>
                <style>
                    * {
                        margin:0;
                        padding:0;
                    }
                    html,body {
                        height:100%;
                        overflow: hidden;
                    }
                    .box {
                        height:100%;
                    }
                </style>
                <script src="https://{{VirtualHostName}}/{{ScriptFileName}}"></script>
            </head>
            <body>
                <div id="root" class="box"></div>
                <script>
                    const chart=echarts.init(document.getElementById('root'){{themeArg}})
                </script>
            </body>
            </html>
            """;
    }

    public Task AddBridgeObject(string key, object bridgeObject)
    {
        var type = bridgeObject.GetType();
        var comVisiableAttr = type.GetCustomAttribute<ComVisibleAttribute>();
        var classInterfaceAttr = type.GetCustomAttribute<ClassInterfaceAttribute>();

        var isFitWebView2 = comVisiableAttr?.Value == true && classInterfaceAttr?.Value == ClassInterfaceType.AutoDual;

        if (!isFitWebView2)
        {
            throw new ApplicationException($"webview object host type {type.FullName} must have [ComVisibleAttribute(true)] and [ClassInterfaceAttribute(ClassInterfaceType.AutoDual)] declaration.");
        }

        coreWebView2.AddHostObjectToScript(key, bridgeObject);
        return Task.CompletedTask;
    }
}
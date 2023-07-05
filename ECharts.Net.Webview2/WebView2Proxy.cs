using Microsoft.Web.WebView2.Core;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ECharts.Net;

public class WebView2Proxy : IWebViewProxy
{
    static WebView2Proxy()
    {
        IWebViewProxy.BridgedObjectHost = "window.chrome.webview.hostObjects.sync";
    }

    public WebView2Proxy(CoreWebView2 webView2)
    {
        coreWebView2 = webView2;
    }

    private readonly CoreWebView2 coreWebView2;

    public Task<string> InvokeScriptAsync(string script)
    {
        return coreWebView2.ExecuteScriptAsync(script);
    }

    public async Task InitializeEchartsEngineAsync()
    {
        var autoResetEvent = new AutoResetEvent(false);

        coreWebView2.NavigationCompleted += NavigationCompleteHandler;
        coreWebView2.NavigateToString(Config.EChartsContainerHtml);

        await Task.Run(() => autoResetEvent.WaitOne());

        async void NavigationCompleteHandler(object? sender, CoreWebView2NavigationCompletedEventArgs _)
        {
            coreWebView2.NavigationCompleted -= NavigationCompleteHandler;
            await coreWebView2.ExecuteScriptAsync(Config.EChartsEngineScript);
            await coreWebView2.ExecuteScriptAsync($"const chart=echarts.init(document.getElementById('{Config.EChartsContainerId}'))");
            autoResetEvent.Set();
        }
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
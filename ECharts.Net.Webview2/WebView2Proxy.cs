using Microsoft.Web.WebView2.Core;

namespace ECharts.Net;

public class WebView2Proxy : IWebViewProxy
{
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
}
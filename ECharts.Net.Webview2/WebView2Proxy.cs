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
        await coreWebView2.ExecuteScriptAsync(Config.EChartsEngineScript);
    }
}
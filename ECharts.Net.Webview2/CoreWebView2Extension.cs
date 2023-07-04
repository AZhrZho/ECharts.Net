using Microsoft.Web.WebView2.Core;

namespace ECharts.Net
{
    public static class CoreWebView2Extension
    {
        public static IWebViewProxy CreateEChartProxy(this CoreWebView2 coreWebView2)
        {
            return new WebView2Proxy(coreWebView2);
        }
    }
}

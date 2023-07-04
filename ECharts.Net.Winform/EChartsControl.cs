using Microsoft.Web.WebView2.Core;

namespace ECharts.Net.Winform;

public partial class EChartsControl : UserControl
{
    public EChartsControl()
    {
        InitializeComponent();
        this.SizeChanged += EChartsControl_SizeChanged;
        webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
        webView.EnsureCoreWebView2Async();
    }

    public event EventHandler? EChartsReady;
    public IWebViewProxy? WebViewProxy { get; private set; }
    public EChartInstance? EChart { get; private set; }

    private void WebView_CoreWebView2InitializationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
    {
        if (!e.IsSuccess)
        {
            throw new ApplicationException("webview2 initialization failed", e.InitializationException);
        }

        webView.NavigationCompleted += NavigationCompleteHandler;
        webView.NavigateToString(ContainerHtml);

        async void NavigationCompleteHandler(object? sender, CoreWebView2NavigationCompletedEventArgs _)
        {
            webView.Invoke(() =>
            {
                webView.NavigationCompleted -= NavigationCompleteHandler;
                WebViewProxy = new WebView2Proxy(webView.CoreWebView2);
            });
            await WebViewProxy!.InitializeEchartsEngineAsync();
            await WebViewProxy.InvokeScriptAsync("const chart=echarts.init(document.getElementById('root'))");
            EChart = new EChartInstance(WebViewProxy);
            EChartsReady?.Invoke(this, new());
        }

        webView.CoreWebView2InitializationCompleted -= WebView_CoreWebView2InitializationCompleted;
    }

    private void EChartsControl_SizeChanged(object? sender, EventArgs e)
    {
        webView.Size = this.Size;
    }

    private const string ContainerHtml =
    """ 
    <!DOCTYPE html>
    <html>
    <head>
        <style>
            * {
                margin:0;
                padding:0;
            }
                html,body{
                height:100%;
            }
            .box{
                height:100%;
            }
        </style>
    </head>
    <body>
        <div id="root" class="box"></div>
    </body>
    </html>
    """;
}
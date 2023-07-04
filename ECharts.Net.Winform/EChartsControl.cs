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

    public Option? ChartOption { get; set; }
    public string? ChartOptionInJs { get; set; }

    private void WebView_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
    {
        webView.CoreWebView2InitializationCompleted -= WebView_CoreWebView2InitializationCompleted;
        if (!e.IsSuccess)
        {
            throw new ApplicationException("webview2 initialization failed", e.InitializationException);
        }

        WebViewProxy = new WebView2Proxy(webView.CoreWebView2);
        WebViewProxy.InitializeEchartsEngineAsync().ContinueWith((_) =>
        {
            webView.Invoke(() =>
            {
                EChart = new EChartInstance(WebViewProxy);
                if (ChartOption is not null) EChart.SetOption(ChartOption);
                else if (!string.IsNullOrEmpty(ChartOptionInJs)) EChart.SetOption(ChartOptionInJs);
                EChartsReady?.Invoke(this, new());
            });
        });
    }

    private void EChartsControl_SizeChanged(object? sender, EventArgs e)
    {
        webView.Size = this.Size;
    }
}
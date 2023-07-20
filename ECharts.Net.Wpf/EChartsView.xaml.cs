using Microsoft.Web.WebView2.Core;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Controls;

namespace ECharts.Net.Wpf;

public partial class EChartsView : UserControl
{
    public EChartsView()
    {
        InitializeComponent();
        webView.EnsureCoreWebView2Async();
        webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
    }

    public event EventHandler? EChartsReady;
    public IWebViewProxy? WebViewProxy { get; private set; }

#if NET
    [NotNull]
#endif
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
            Dispatcher.Invoke(() => 
            {
                WebViewProxy.InvokeScriptAsync("window.addEventListener('resize', function(){ chart.resize() })");
                EChart = new EChartInstance(WebViewProxy);
                if (ChartOption is not null) EChart.SetOption(ChartOption);
                else if (!string.IsNullOrEmpty(ChartOptionInJs)) EChart.SetOption(ChartOptionInJs!);
                EChartsReady?.Invoke(this, new());
            });
        });
    }
}

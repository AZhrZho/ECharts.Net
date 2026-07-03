using Microsoft.Web.WebView2.Core;
using System.Windows.Forms;
using WinFormsTimer = System.Windows.Forms.Timer;

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
    /// <summary>
    /// 自定义容器 HTML，设置后替代默认模板
    /// </summary>
    public string? ContainerHtml { get; set; }

    /// <summary>
    /// 自定义容器中图表 div 的元素 ID，默认 "root"
    /// </summary>
    public string? ContainerElementId { get; set; }
    public bool NotMerge { get; set; }
    public bool LazyUpdate { get; set; }
    public bool IsDark { get; set; } = false;

    private bool _loading;
    public bool Loading
    {
        get => _loading;
        set
        {
            _loading = value;
            if (EChart == null) return;
            if (value) EChart.ShowLoading();
            else EChart.HideLoading();
        }
    }

    private WinFormsTimer? _resizeDebounceTimer;

    private void WebView_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
    {
        webView.CoreWebView2InitializationCompleted -= WebView_CoreWebView2InitializationCompleted;
        if (!e.IsSuccess)
        {
            throw new ApplicationException("webview2 initialization failed", e.InitializationException);
        }

        var proxy = new WebView2Proxy(webView.CoreWebView2);
        proxy.ContainerHtml = ContainerHtml;
        proxy.ContainerElementId = ContainerElementId;
        WebViewProxy = proxy;
        WebViewProxy.InitializeEchartsEngineAsync().ContinueWith((_) =>
        {
            webView.Invoke(() =>
            {
                WebViewProxy.InvokeScriptAsync("window.addEventListener('resize', function(){ chart.resize() })");
                EChart = new EChartInstance(WebViewProxy);
                if (Loading) EChart.ShowLoading();
                if (ChartOption is not null) EChart.SetOption(ChartOption, notMerge: NotMerge, lazyUpdate: LazyUpdate);
                else if (!string.IsNullOrEmpty(ChartOptionInJs)) EChart.SetOption(ChartOptionInJs, notMerge: NotMerge, lazyUpdate: LazyUpdate);
                EChartsReady?.Invoke(this, new());
            });
        });
    }

    private void EChartsControl_SizeChanged(object? sender, EventArgs e)
    {
        webView.Size = this.Size;
        if (_resizeDebounceTimer == null)
        {
            _resizeDebounceTimer = new WinFormsTimer { Interval = 16 };
            _resizeDebounceTimer.Tick += OnResizeDebounceTick;
        }
        _resizeDebounceTimer.Stop();
        _resizeDebounceTimer.Start();
    }

    private void OnResizeDebounceTick(object? sender, EventArgs e)
    {
        _resizeDebounceTimer!.Stop();
        EChart?.Resize();
    }
}
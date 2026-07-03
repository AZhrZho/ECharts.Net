using Microsoft.Web.WebView2.Core;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

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

#if NET6_0_OR_GREATER
    [NotNull]
#endif
    public EChartInstance? EChart { get; private set; }

    public Option? ChartOption { get; set; }
    public string? ChartOptionInJs { get; set; }
    public string? ContainerHtml
    {
        get => (string?)GetValue(ContainerHtmlProperty);
        set => SetValue(ContainerHtmlProperty, value);
    }

    public string? ContainerElementId
    {
        get => (string?)GetValue(ContainerElementIdProperty);
        set => SetValue(ContainerElementIdProperty, value);
    }

    // option 依赖属性
    public static readonly DependencyProperty DepOptionProperty =
            DependencyProperty.Register("DepOption", typeof(Option), typeof(EChartsView),
                new PropertyMetadata(null, OnDepOptionChanged));
    // JS 依赖属性
    public static readonly DependencyProperty DepOptionInJsProperty =
            DependencyProperty.Register("DepOptionInJs", typeof(string), typeof(EChartsView),
                new PropertyMetadata(null, OnDepOptionInJsChanged));
    // NotMerge 依赖属性
    public static readonly DependencyProperty NotMergeProperty =
            DependencyProperty.Register("NotMerge", typeof(bool), typeof(EChartsView),
                new PropertyMetadata(false));
    // LazyUpdate 依赖属性
    public static readonly DependencyProperty LazyUpdateProperty =
            DependencyProperty.Register("LazyUpdate", typeof(bool), typeof(EChartsView),
                new PropertyMetadata(false));
    // Loading 依赖属性
    public static readonly DependencyProperty LoadingProperty =
            DependencyProperty.Register("Loading", typeof(bool), typeof(EChartsView),
                new PropertyMetadata(false, OnLoadingChanged));
    // 自定义容器 HTML 依赖属性，设置后替代默认模板
    public static readonly DependencyProperty ContainerHtmlProperty =
            DependencyProperty.Register("ContainerHtml", typeof(string), typeof(EChartsView),
                new PropertyMetadata(null));
    // 自定义容器中图表 div 的元素 ID，默认 "root"
    public static readonly DependencyProperty ContainerElementIdProperty =
            DependencyProperty.Register("ContainerElementId", typeof(string), typeof(EChartsView),
                new PropertyMetadata(null));

    // 是否为深色模式
    public static readonly DependencyProperty IsDarkProperty =
        DependencyProperty.Register("IsDark", typeof(bool), typeof(EChartsView), new PropertyMetadata(false, OnIsDarkChanged));

    public Option DepOption
    {
        get { return (Option)GetValue(DepOptionProperty); }
        set { SetValue(DepOptionProperty, value); }
    }

    public string DepOptionInJs
    {
        get { return (string)GetValue(DepOptionInJsProperty); }
        set { SetValue(DepOptionInJsProperty, value); }
    }
    public bool IsDark
    {
        get { return (bool)GetValue(IsDarkProperty); }
        set { SetValue(IsDarkProperty, value); }
    }

    public bool NotMerge
    {
        get { return (bool)GetValue(NotMergeProperty); }
        set { SetValue(NotMergeProperty, value); }
    }

    public bool LazyUpdate
    {
        get { return (bool)GetValue(LazyUpdateProperty); }
        set { SetValue(LazyUpdateProperty, value); }
    }

    public bool Loading
    {
        get { return (bool)GetValue(LoadingProperty); }
        set { SetValue(LoadingProperty, value); }
    }

    private static void OnLoadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var view = (EChartsView)d;
        if (view.EChart == null) return;
        if ((bool)e.NewValue) view.EChart.ShowLoading();
        else view.EChart.HideLoading();
    }

    private DispatcherTimer? _optionDebounceTimer;
    private Option? _pendingOption;

    private static void OnDepOptionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var view = (EChartsView)d;
        var newOption = e.NewValue as Option;
        if (newOption == null || newOption.Series == null) return;

        if (view.EChart != null)
        {
            view._pendingOption = newOption;
            view.StartOptionDebounce();
        }
        else
        {
            view.ChartOption = newOption;
        }
    }

    private void StartOptionDebounce()
    {
        if (_optionDebounceTimer == null)
        {
            _optionDebounceTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(16) };
            _optionDebounceTimer.Tick += OnOptionDebounceTick;
        }
        else
        {
            _optionDebounceTimer.Stop();
        }
        _optionDebounceTimer.Start();
    }

    private void OnOptionDebounceTick(object? sender, EventArgs e)
    {
        _optionDebounceTimer!.Stop();
        if (_pendingOption != null && EChart != null)
        {
            EChart.SetOption(_pendingOption, notMerge: NotMerge, lazyUpdate: LazyUpdate);
            _pendingOption = null;
        }
    }

    private DispatcherTimer? _jsOptionDebounceTimer;
    private string? _pendingJsOption;

    private static void OnDepOptionInJsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var view = (EChartsView)d;
        var newOption = e.NewValue as string;
        if (string.IsNullOrEmpty(newOption)) return;

        if (view.EChart != null)
        {
            view._pendingJsOption = newOption;
            view.StartJsOptionDebounce();
        }
        else
        {
            view.ChartOptionInJs = newOption;
        }
    }

    private void StartJsOptionDebounce()
    {
        if (_jsOptionDebounceTimer == null)
        {
            _jsOptionDebounceTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(16) };
            _jsOptionDebounceTimer.Tick += OnJsOptionDebounceTick;
        }
        else
        {
            _jsOptionDebounceTimer.Stop();
        }
        _jsOptionDebounceTimer.Start();
    }

    private void OnJsOptionDebounceTick(object? sender, EventArgs e)
    {
        _jsOptionDebounceTimer!.Stop();
        if (_pendingJsOption != null && EChart != null)
        {
            EChart.SetOption(_pendingJsOption, notMerge: NotMerge, lazyUpdate: LazyUpdate);
            _pendingJsOption = null;
        }
    }

    private static void OnIsDarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var view = (EChartsView)d;
        view?.EChart?.SetTheme((bool)e.NewValue);
    }

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
            Dispatcher.Invoke(() =>
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
}

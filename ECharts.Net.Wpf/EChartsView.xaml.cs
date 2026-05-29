using Microsoft.Web.WebView2.Core;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
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

#if NET6_0_OR_GREATER
    [NotNull]
#endif
    public EChartInstance? EChart { get; private set; }

    public Option? ChartOption { get; set; }
    public string? ChartOptionInJs { get; set; }

    // option 依赖属性
    public static readonly DependencyProperty DepOptionProperty =
            DependencyProperty.Register("DepOption", typeof(Option), typeof(EChartsView),
                new PropertyMetadata(null, OnDepOptionChanged));
    // JS 依赖属性
    public static readonly DependencyProperty DepOptionInJsProperty =
            DependencyProperty.Register("DepOptionInJs", typeof(string), typeof(EChartsView),
                new PropertyMetadata(null, OnDepOptionInJsChanged));

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

    private static void OnDepOptionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var view = (EChartsView)d;
        var newOption = e.NewValue as Option;
        if (newOption == null || newOption.Series == null) return;

        // 如果图表已就绪，直接更新
        if (view.EChart != null)
        {
            view.EChart.SetOption(newOption);
        }
        // 否则，暂存起来，等待图表就绪
        else
        {
            view.ChartOption = newOption;
        }
    }

    private static void OnDepOptionInJsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var view = (EChartsView)d;
        var newOption = e.NewValue as string;
        if (string.IsNullOrEmpty(newOption)) return;

        // 如果图表已就绪，直接更新
        if (view.EChart != null)
        {
            view.EChart.SetOption(newOption);
        }
        // 否则，暂存起来，等待图表就绪
        else
        {
            view.ChartOptionInJs = newOption;
        }
    }

    private static void OnIsDarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var view = (EChartsView)d;
        var curChgVaule = e.NewValue as bool?;
        bool isDark = curChgVaule ?? false;
        view?.EChart?.SetTheme(isDark);
    }

    private void WebView_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
    {
        webView.CoreWebView2InitializationCompleted -= WebView_CoreWebView2InitializationCompleted;
        if (!e.IsSuccess)
        {
            throw new ApplicationException("webview2 initialization failed", e.InitializationException);
        }

        WebViewProxy = new WebView2Proxy(webView.CoreWebView2);
        WebViewProxy.InitializeEchartsEngineAsync(IsDark).ContinueWith((_) =>
        {
            Dispatcher.Invoke(() =>
            {
                WebViewProxy.InvokeScriptAsync("window.addEventListener('resize', function(){ chart.resize() })");
                EChart = new EChartInstance(WebViewProxy);
                if (ChartOption is not null) EChart.SetOption(ChartOption);
                else if (!string.IsNullOrEmpty(ChartOptionInJs)) EChart.SetOption(ChartOptionInJs);
                EChartsReady?.Invoke(this, new());
            });
        });
    }
}

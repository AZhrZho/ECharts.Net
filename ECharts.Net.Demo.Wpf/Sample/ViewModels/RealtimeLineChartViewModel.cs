using System;
using System.Collections.Generic;
using System.Windows.Threading;
using ECharts.Net.Util;

namespace ECharts.Net.Demo.Wpf.Sample.ViewModels;

public class RealtimeLineChartViewModel : BindableBase, IDisposable
{
    private DispatcherTimer? _timer;
    private readonly List<string> _times = new();
    private readonly List<double> _values = new();
    private readonly Random _random = new();

    private Option? _chartOption;
    public Option? ChartOption
    {
        get => _chartOption;
        set => SetProperty(ref _chartOption, value);
    }

    private string? _chartOptionInJs;
    public string? ChartOptionInJs
    {
        get => _chartOptionInJs;
        set => SetProperty(ref _chartOptionInJs, value);
    }

    private bool _isLoading = true;
    public bool IsLoading
    {
        get => _isLoading;
        set => SetProperty(ref _isLoading, value);
    }

    public RealtimeLineChartViewModel()
    {
        for (int i = 9; i >= 0; i--)
        {
            _times.Add(DateTime.Now.AddSeconds(-i).ToString("HH:mm:ss"));
            _values.Add(_random.Next(50, 200));
        }
        UpdateChart();

        var loadingTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
        loadingTimer.Tick += (_, _) =>
        {
            loadingTimer.Stop();
            IsLoading = false;
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += OnTimerTick;
            _timer.Start();
        };
        loadingTimer.Start();
    }

    private void OnTimerTick(object? sender, EventArgs e)
    {
        _times.Add(DateTime.Now.ToString("HH:mm:ss"));
        _values.Add(_random.Next(50, 200));

        if (_times.Count > 20)
        {
            _times.RemoveAt(0);
            _values.RemoveAt(0);
        }

        UpdateChart();
    }

    private void UpdateChart()
    {
        ChartOption = new Option
        {
            Title = new Title { Text = "实时数据更新 (Option)" },
            Tooltip = new Tooltip { Trigger = TooltipTrigger.Axis },
            XAxis = new XAxis
            {
                Type = AxisType.Category,
                Data = new List<string>(_times)
            },
            YAxis = new YAxis
            {
                Type = AxisType.Value,
                Min = 0,
                Max = 250
            },
            Series = new Series[]
            {
                new LineSeries
                {
                    Data = new List<double>(_values),
                    ShowSymbol = false
                }
            }
        };

        var timesJson = System.Text.Json.JsonSerializer.Serialize(_times);
        var valuesJson = System.Text.Json.JsonSerializer.Serialize(_values);
        ChartOptionInJs = $$"""
        {
            "title": { "text": "实时数据更新 (JS)" },
            "tooltip": { "trigger": "axis" },
            "xAxis": { "type": "category", "data": {{timesJson}} },
            "yAxis": { "type": "value", "min": 0, "max": 250 },
            "series": [{ "type": "line", "data": {{valuesJson}}, "showSymbol": false }]
        }
        """;
    }

    public void Dispose()
    {
        _timer?.Stop();
    }
}

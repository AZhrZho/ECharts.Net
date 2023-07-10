﻿using System.Windows.Controls;

namespace ECharts.Net.Demo.Wpf.Sample.Line;

public partial class SmoothedLineChart : UserControl
{
    public SmoothedLineChart()
    {
        InitializeComponent();
        // https://echarts.apache.org/examples/en/editor.html?c=line-smooth
        var option = new Option
        {
            XAxis = new()
            {
                Type = AxisType.Category,
                Data = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" }
            },
            YAxis = new()
            {
                Type = AxisType.Value,
            },
            Series = new Series[]
            {
                new LineSeries()
                {
                    Data = new double[] { 820, 932, 901, 934, 1290, 1330, 1320 },
                    Smooth = true,
                }
            }
        };
        chart.ChartOption = option;
    }
}

using System.Windows.Controls;

namespace ECharts.Net.Demo.Wpf.Sample.Line;

public partial class BasicLineChart : UserControl
{
    public BasicLineChart()
    {
        InitializeComponent();
        // https://echarts.apache.org/examples/en/editor.html?c=line-simple
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
                    Data = new double[] {150, 230, 224, 218, 135, 260 }
                }
            }
        };
        chart.ChartOption = option;
    }
}

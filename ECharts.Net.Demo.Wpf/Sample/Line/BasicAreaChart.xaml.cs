using System.Windows.Controls;

namespace ECharts.Net.Demo.Wpf.Sample.Line;

public partial class BasicAreaChart : UserControl
{
    public BasicAreaChart()
    {
        InitializeComponent();
        // https://echarts.apache.org/examples/en/editor.html?c=area-basic
        var option = new Option
        {
            XAxis = new XAxis()
            {
                Type = AxisType.Category,
                BoundaryGap = false,
                Data = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" }
            },
            YAxis = new YAxis()
            {
                Type = AxisType.Value,
            },
            Series = new Series[]
            {
                new LineSeries()
                {
                    Data = new double[] { 820, 932, 901, 934, 1290, 1330, 1320 },
                    AreaStyle = new()
                }
            }
        };
        chart.ChartOption = option;
    }
}

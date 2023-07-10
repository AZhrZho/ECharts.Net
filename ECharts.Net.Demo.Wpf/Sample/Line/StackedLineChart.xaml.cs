using System.Windows.Controls;

namespace ECharts.Net.Demo.Wpf.Sample.Line;

public partial class StackedLineChart : UserControl
{
    public StackedLineChart()
    {
        InitializeComponent();
        // https://echarts.apache.org/examples/en/editor.html?c=line-stack
        var option = new Option
        {
            Title = new Title
            {
                Text = "Stacked Line"
            },
            // TODO: Demo: StackedLineChart - Add ToolTip, Legend, Grid, Toolbox
            // ToolTip
            // Legend
            // Grid
            // Toolbox
            XAxis = new()
            {
                Type = AxisType.Category,
                BoundaryGap = false,
                Data = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" }
            },
            YAxis = new()
            {
                Type = AxisType.Value
            },
            Series = new Series[]
            {
                new LineSeries()
                {
                    Name = "Email",
                    Stack = "Total",
                    Data = new double[]{ 120, 132, 101, 134, 90, 230, 210 }
                },
                new LineSeries()
                {
                    Name = "Union Ads",
                    Stack = "Total",
                    Data = new double[]{ 220, 182, 191, 234, 290, 330, 310 }
                },
                new LineSeries()
                {
                    Name = "Video Ads",
                    Stack = "Total",
                    Data = new double[]{ 150, 232, 201, 154, 190, 330, 410 }
                },
                new LineSeries()
                {
                    Name = "Direct",
                    Stack = "Total",
                    Data = new double[]{ 320, 332, 301, 334, 390, 330, 320 }
                },
                new LineSeries()
                {
                    Name = "Search Engine",
                    Stack = "Total",
                    Data = new double[]{ 820, 932, 901, 934, 1290, 1330, 1320 }
                }
            }
        };
        chart.ChartOption = option;
    }
}

using System.Drawing;
using System.Windows.Controls;

namespace ECharts.Net.Demo.Wpf.Sample.Line
{
    /// <summary>
    /// StackedAreaChart.xaml 的交互逻辑
    /// </summary>
    public partial class StackedAreaChart : UserControl
    {
        public StackedAreaChart()
        {
            InitializeComponent();
            // https://echarts.apache.org/examples/en/editor.html?c=area-stack
            var option = new Option
            {
                Title = new Title
                {
                    Text = "Stacked Area Chart"
                },
                Tooltip = new()
                {
                    Trigger = TooltipTrigger.Axis,
                    AxisPointer = new()
                    {
                        Type = PointerType.Cross,
                        Label = new()
                        {
                            BackgroundColor = EChartsColor.Argb(0xff, 0x6a, 0x79, 0x85)
                        }
                    },
                },
                Legend = new Legend
                {
                    Data = new LegendData[] { "Email", "Union Ads", "Video Ads", "Direct", "Search Engine" }
                },
                Toolbox = new()
                {
                    Feature = new Feature()
                    {
                        SaveAsImage = new()
                    }
                },
                Grid = new Grid()
                {
                    Left = "3%",
                    Right = "4%",
                    Bottom = "3%",
                    ContainLabel = true
                },
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
                        AreaStyle = new(),
                        Emphasis = new()
                        {
                            Focus = LineSeries.FocusType.Series
                        },
                        Data = new double[]{ 120, 132, 101, 134, 90, 230, 210 }
                    },
                    new LineSeries()
                    {
                        Name = "Union Ads",
                        Stack = "Total",
                        AreaStyle = new(),
                        Emphasis = new()
                        {
                            Focus = LineSeries.FocusType.Series
                        },
                        Data = new double[]{ 220, 182, 191, 234, 290, 330, 310 }
                    },
                    new LineSeries()
                    {
                        Name = "Video Ads",
                        Stack = "Total",
                        AreaStyle = new(),
                        Emphasis = new()
                        {
                            Focus = LineSeries.FocusType.Series
                        },
                        Data = new double[]{ 150, 232, 201, 154, 190, 330, 410 }
                    },
                    new LineSeries()
                    {
                        Name = "Direct",
                        Stack = "Total",
                        AreaStyle = new(),
                        Emphasis = new()
                        {
                            Focus = LineSeries.FocusType.Series
                        },
                        Data = new double[]{ 320, 332, 301, 334, 390, 330, 320 }
                    },
                    new LineSeries()
                    {
                        Name = "Search Engine",
                        Stack = "Total",
                        AreaStyle = new(),
                        Emphasis = new()
                        {
                            Focus = LineSeries.FocusType.Series
                        },
                        Data = new double[]{ 820, 932, 901, 934, 1290, 1330, 1320 }
                    }
                }
            };
            chart.ChartOption = option;
        }
    }
}

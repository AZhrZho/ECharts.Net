using System.Windows.Controls;

namespace ECharts.Net.Demo.Wpf.Sample.Line
{
    /// <summary>
    /// GradientStackedAreaChart.xaml 的交互逻辑
    /// </summary>
    public partial class GradientStackedAreaChart : UserControl
    {
        public GradientStackedAreaChart()
        {
            InitializeComponent();
            var option = new Option
            {
                Color = new EChartsColor[]
                {
                    EChartsColor.Hex(0x80FFA5), EChartsColor.Hex(0x00DDFF), EChartsColor.Hex(0x37A2FF),
                    EChartsColor.Hex(0xFF0087), EChartsColor.Hex(0xFFBF00)
                },
                Title = new Title
                {
                    Text = "Gradient Stacked Area Chart"
                },
                Tooltip = new()
                {
                    Trigger = TooltipTrigger.Axis,
                    AxisPointer = new()
                    {
                        Type = PointerType.Cross,
                        Label = new()
                        {
                            BackgroundColor = EChartsColor.Hex(0xFF6A7985)
                        }
                    }
                },
                Legend = new Legend
                {
                    Data = new LegendData[] { "Line1", "Line2", "Line3", "Line4", "Line5" }
                },
                Toolbox = new()
                {
                    Feature = new Feature
                    {
                        SaveAsImage = new()
                    }
                },
                Grid = new Grid
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
                Series = new[]
                {
                    new LineSeries
                    {
                        Name = "Line1",
                        Stack = "Total",
                        Smooth = true,
                        LineStyle = new()
                        {
                            Width = 0
                        },
                        ShowSymbol = false,
                        AreaStyle = new()
                        {
                            Opacity = 0.8,
                            Color = new LinearGradientColor
                            {
                                X = 0,  Y = 0,
                                X2 = 0, Y2 = 1,
                                ColorStops = new[]
                                {
                                    new GradientColorStop
                                    {
                                         Offset = 0,
                                         Color = EChartsColor.Rgb(128, 255, 165)
                                    },
                                    new GradientColorStop
                                    {
                                         Offset = 1,
                                         Color = EChartsColor.Rgb(1, 191, 236)
                                    },
                                }
                            }
                        },
                        Emphasis = new()
                        {
                            Focus = LineSeries.FocusType.Series
                        },
                        Data = new double[]{ 140, 232, 101, 264, 90, 340, 250 }
                    },
                    new LineSeries
                    {
                        Name = "Line2",
                        Stack = "Total",
                        Smooth = true,
                        LineStyle = new()
                        {
                            Width = 0
                        },
                        ShowSymbol = false,
                        AreaStyle = new()
                        {
                            Opacity = 0.8,
                            Color = new LinearGradientColor
                            {
                                X = 0,  Y = 0,
                                X2 = 0, Y2 = 1,
                                ColorStops = new[]
                                {
                                    new GradientColorStop
                                    {
                                         Offset = 0,
                                         Color = EChartsColor.Rgb(0, 221, 255)
                                    },
                                    new GradientColorStop
                                    {
                                         Offset = 1,
                                         Color = EChartsColor.Rgb(77, 119, 255)
                                    },
                                }
                            }
                        },
                        Emphasis = new()
                        {
                            Focus = LineSeries.FocusType.Series
                        },
                        Data = new double[]{ 120, 282, 111, 234, 220, 340, 310 }
                    },
                    new LineSeries
                    {
                        Name = "Line3",
                        Stack = "Total",
                        Smooth = true,
                        LineStyle = new()
                        {
                            Width = 0
                        },
                        ShowSymbol = false,
                        AreaStyle = new()
                        {
                            Opacity = 0.8,
                            Color = new LinearGradientColor
                            {
                                X = 0,  Y = 0,
                                X2 = 0, Y2 = 1,
                                ColorStops = new[]
                                {
                                    new GradientColorStop
                                    {
                                         Offset = 0,
                                         Color = EChartsColor.Rgb(55, 162, 255)
                                    },
                                    new GradientColorStop
                                    {
                                         Offset = 1,
                                         Color = EChartsColor.Rgb(116, 21, 219)
                                    },
                                }
                            }
                        },
                        Emphasis = new()
                        {
                            Focus = LineSeries.FocusType.Series
                        },
                        Data = new double[]{ 320, 132, 201, 334, 190, 130, 220 }
                    },
                    new LineSeries
                    {
                        Name = "Line4",
                        Stack = "Total",
                        Smooth = true,
                        LineStyle = new()
                        {
                            Width = 0
                        },
                        ShowSymbol = false,
                        AreaStyle = new()
                        {
                            Opacity = 0.8,
                            Color = new LinearGradientColor
                            {
                                X = 0,  Y = 0,
                                X2 = 0, Y2 = 1,
                                ColorStops = new[]
                                {
                                    new GradientColorStop
                                    {
                                         Offset = 0,
                                         Color = EChartsColor.Rgb(255, 0, 135)
                                    },
                                    new GradientColorStop
                                    {
                                         Offset = 1,
                                         Color = EChartsColor.Rgb(135, 0, 157)
                                    },
                                }
                            }
                        },
                        Emphasis = new()
                        {
                            Focus = LineSeries.FocusType.Series
                        },
                        Data = new double[]{ 220, 402, 231, 134, 190, 230, 120 }
                    },
                    new LineSeries
                    {
                        Name = "Line5",
                        Stack = "Total",
                        Smooth = true,
                        LineStyle = new()
                        {
                            Width = 0
                        },
                        ShowSymbol = false,
                        AreaStyle = new()
                        {
                            Opacity = 0.8,
                            Color = new LinearGradientColor
                            {
                                X = 0,  Y = 0,
                                X2 = 0, Y2 = 1,
                                ColorStops = new[]
                                {
                                    new GradientColorStop
                                    {
                                         Offset = 0,
                                         Color = EChartsColor.Rgb(255, 191, 0)
                                    },
                                    new GradientColorStop
                                    {
                                         Offset = 1,
                                         Color = EChartsColor.Rgb(224, 62, 76)
                                    },
                                }
                            }
                        },
                        Emphasis = new()
                        {
                            Focus = LineSeries.FocusType.Series
                        },
                        Data = new double[]{ 220, 302, 181, 234, 210, 290, 150 }
                    }
                }
            };

            chart.ChartOption = option;
        }
    }
}

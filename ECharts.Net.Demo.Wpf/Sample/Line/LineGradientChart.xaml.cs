using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ECharts.Net.Demo.Wpf.Sample.Line
{
    /// <summary>
    /// LineGradientChart.xaml 的交互逻辑
    /// </summary>
    public partial class LineGradientChart : UserControl
    {
        public LineGradientChart()
        {
            InitializeComponent();

            // https://echarts.apache.org/examples/zh/editor.html?c=line-gradient
            List<object[]> data = new List<object[]>
            {
                new object[] { "2000-06-05", 116.0 }, new object[] { "2000-06-06", 129.0 }, new object[] { "2000-06-07", 135.0 }, new object[] { "2000-06-08", 86.0 },
                new object[] { "2000-06-09", 73.0 }, new object[] { "2000-06-10", 85.0 }, new object[] { "2000-06-11", 73.0 }, new object[] { "2000-06-12", 68.0 },
                new object[] { "2000-06-13", 92.0 }, new object[] { "2000-06-14", 130.0 }, new object[] { "2000-06-15", 245.0 }, new object[] { "2000-06-16", 139.0 },
                new object[] { "2000-06-17", 115.0 }, new object[] { "2000-06-18", 111.0 }, new object[] { "2000-06-19", 309.0 }, new object[] { "2000-06-20", 206.0 },
                new object[] { "2000-06-21", 137.0 }, new object[] { "2000-06-22", 128.0 }, new object[] { "2000-06-23", 85.0 }, new object[] { "2000-06-24", 94.0 },
                new object[] { "2000-06-25", 71.0 }, new object[] { "2000-06-26", 106.0 }, new object[] { "2000-06-27", 84.0 }, new object[] { "2000-06-28", 93.0 },
                new object[] { "2000-06-29", 85.0 }, new object[] { "2000-06-30", 73.0 }, new object[] { "2000-07-01", 83.0 }, new object[] { "2000-07-02", 125.0 },
                new object[] { "2000-07-03", 107.0 }, new object[] { "2000-07-04", 82.0 }, new object[] { "2000-07-05", 44.0 }, new object[] { "2000-07-06", 72.0 },
                new object[] { "2000-07-07", 106.0 }, new object[] { "2000-07-08", 107.0 }, new object[] { "2000-07-09", 66.0 }, new object[] { "2000-07-10", 91.0 },
                new object[] { "2000-07-11", 92.0 }, new object[] { "2000-07-12", 113.0 }, new object[] { "2000-07-13", 107.0 }, new object[] { "2000-07-14", 131.0 },
                new object[] { "2000-07-15", 111.0 }, new object[] { "2000-07-16", 64.0 }, new object[] { "2000-07-17", 69.0 }, new object[] { "2000-07-18", 88.0 },
                new object[] { "2000-07-19", 77.0 }, new object[] { "2000-07-20", 83.0 }, new object[] { "2000-07-21", 111.0 }, new object[] { "2000-07-22", 57.0 },
                new object[] { "2000-07-23", 55.0 }, new object[] { "2000-07-24", 60.0 }
            };

            var dateList = new List<string>();
            var valueList = new List<double>();

            foreach (var item in data)
            {
                dateList.Add((string)item[0]);
                valueList.Add((double)item[1]);
            }

            var option = new Option
            {
                VisualMap = new List<VisualMap>
                {
                    new VisualMapContinuous
                    {
                        Show = false,
                        SeriesIndex = 0,
                        Min = 0,
                        Max = 400
                    },
                    new VisualMapContinuous
                    {
                        Show = false,
                        SeriesIndex = 1,
                        Dimension = 0,
                        Min = 0,
                        Max = dateList.Count - 1
                    }
                },
                Title = new List<Title>
                {
                    new Title
                    {
                        Left = "center",
                        Text = "Gradient along the y axis"
                    },
                    new Title
                    {
                        Top = "55%",
                        Left = "center",
                        Text = "Gradient along the x axis"
                    }
                },
                Tooltip = new Tooltip
                {
                    Trigger = TooltipTrigger.Axis
                },
                XAxis = new List<XAxis>
                {
                    new XAxis
                    {
                        Data = dateList
                    },
                    new XAxis
                    {
                        Data = dateList,
                        GridIndex = 1
                    }
                },
                YAxis = new List<YAxis>
                {
                    new YAxis { }, // 空对象
                    new YAxis
                    {
                        GridIndex = 1
                    }
                },
                Grid = new List<Grid>
                {
                    new Grid
                    {
                        Bottom = "60%"
                    },
                    new Grid
                    {
                        Top = "60%"
                    }
                },
                Series = new List<Series>
                {
                    new LineSeries
                    {
                        Type = SeriesType.Line,
                        ShowSymbol = false,
                        Data = valueList
                    },
                    new LineSeries
                    {
                        Type = SeriesType.Line,
                        ShowSymbol = false,
                        Data = valueList,
                        XAxisIndex = 1,
                        YAxisIndex = 1
                    }
                }
            };
            chart.ChartOption = option;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ECharts.Net.Demo.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            chart1.ChartOption = chartOption1;
            chart2.ChartOptionInJs = chartOption2;
            chart3.ChartOptionInJs = chartOption3;
        }

        private readonly static Option chartOption1 = new()
        {
            Title = new Title() { Text = "DemoChart" },
            XAxis = new()
            {
                Type = AxisType.Category,
                Data = Enumerable.Range(1, 10).Select(x => x.ToString()).ToList()
            },
            YAxis = new()
            {
                Type = AxisType.Value
            },
            Series = new List<Series>
            {
                new LineSeries()
                {
                    Name = "Data",
                    Step = LineSeries.SeriesStep.Middle,
                    Type = SeriesType.Line,
                    Data = Enumerable.Range(1, 10).Select(x => (double)x * 10).Select(x => x.ToString()).ToList()
                }
            }
        };

        private readonly static string chartOption2 =
        """
        {
            title: {
            text: 'Distribution of Electricity',
            subtext: 'Fake Data'
            },
            tooltip: {
            trigger: 'axis',
            axisPointer: {
                type: 'cross'
            }
            },
            toolbox: {
            show: true,
            feature: {
                saveAsImage: {}
            }
            },
            xAxis: {
            type: 'category',
            boundaryGap: false,
            // prettier-ignore
            data: ['00:00', '01:15', '02:30', '03:45', '05:00', '06:15', '07:30', '08:45', '10:00', '11:15', '12:30', '13:45', '15:00', '16:15', '17:30', '18:45', '20:00', '21:15', '22:30', '23:45']
            },
            yAxis: {
            type: 'value',
            axisLabel: {
                formatter: '{value} W'
            },
            axisPointer: {
                snap: true
            }
            },
            visualMap: {
            show: false,
            dimension: 0,
            pieces: [
                {
                lte: 6,
                color: 'green'
                },
                {
                gt: 6,
                lte: 8,
                color: 'red'
                },
                {
                gt: 8,
                lte: 14,
                color: 'green'
                },
                {
                gt: 14,
                lte: 17,
                color: 'red'
                },
                {
                gt: 17,
                color: 'green'
                }
            ]
            },
            series: [
            {
                name: 'Electricity',
                type: 'line',
                smooth: true,
                // prettier-ignore
                data: [300, 280, 250, 260, 270, 300, 550, 500, 400, 390, 380, 390, 400, 500, 600, 750, 800, 700, 600, 400],
                markArea: {
                itemStyle: {
                    color: 'rgba(255, 173, 177, 0.4)'
                },
                data: [
                    [
                    {
                        name: 'Morning Peak',
                        xAxis: '07:30'
                    },
                    {
                        xAxis: '10:00'
                    }
                    ],
                    [
                    {
                        name: 'Evening Peak',
                        xAxis: '17:30'
                    },
                    {
                        xAxis: '21:15'
                    }
                    ]
                ]
                }
            }
            ]
        }
        """;

        private readonly static string chartOption3 =
        """
        {
          legend: {},
          tooltip: {},
          dataset: {
            source: [
              ['product', '2012', '2013', '2014', '2015'],
              ['Matcha Latte', 41.1, 30.4, 65.1, 53.3],
              ['Milk Tea', 86.5, 92.1, 85.7, 83.1],
              ['Cheese Cocoa', 24.1, 67.2, 79.5, 86.4]
            ]
          },
          xAxis: [
            { type: 'category', gridIndex: 0 },
            { type: 'category', gridIndex: 1 }
          ],
          yAxis: [{ gridIndex: 0 }, { gridIndex: 1 }],
          grid: [{ bottom: '55%' }, { top: '55%' }],
          series: [
            // These series are in the first grid.
            { type: 'bar', seriesLayoutBy: 'row' },
            { type: 'bar', seriesLayoutBy: 'row' },
            { type: 'bar', seriesLayoutBy: 'row' },
            // These series are in the second grid.
            { type: 'bar', xAxisIndex: 1, yAxisIndex: 1 },
            { type: 'bar', xAxisIndex: 1, yAxisIndex: 1 },
            { type: 'bar', xAxisIndex: 1, yAxisIndex: 1 },
            { type: 'bar', xAxisIndex: 1, yAxisIndex: 1 }
          ]
        }
        """;
    }
}

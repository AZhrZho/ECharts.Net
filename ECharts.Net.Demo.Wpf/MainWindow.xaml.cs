using System;
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
        }

        private void BtnInitChart_Click(object sender, RoutedEventArgs e)
        {
            var option = new Option
            {
                Title = new() { Text = "DemoChart" },
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
                    new()
                    {
                        Name = "Data",
                        Step = SeriesStep.Middle,
                        Type = SeriesType.Line,
                        Data = Enumerable.Range(1, 10).Select(x => (double)x* 10).ToList()
                    }
                }
            };
            echart.EChart!.SetOption(option);
        }

        private void OnEChartsReady(object sender, EventArgs e)
        {
            OperationPanel.IsEnabled = true;
        }
    }
}

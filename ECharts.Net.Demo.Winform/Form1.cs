namespace ECharts.Net.Demo.Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Enabled = false;
            chart.EChartsReady += Chart_EChartsReady;
        }

        private void Chart_EChartsReady(object? sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void BtnInitChart_Click(object sender, EventArgs e)
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
            chart.EChart!.SetOption(option);
        }
    }
}
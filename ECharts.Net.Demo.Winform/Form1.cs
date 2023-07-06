namespace ECharts.Net.Demo.Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var option = new Option
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
            chart.ChartOption = option;
        }
    }
}
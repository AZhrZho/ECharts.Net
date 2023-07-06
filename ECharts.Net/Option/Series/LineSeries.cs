namespace ECharts.Net;

public class LineSeries : Series
{
    public SeriesStep? Step { get; set; }

    public new IList<string>? Data { get; set; }

    public enum SeriesStep
    {
        Start,
        Middle,
        End,
    }
}

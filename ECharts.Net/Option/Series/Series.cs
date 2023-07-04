namespace ECharts.Net;

public class Series
{
    public string? Name { get; set; }
    public SeriesType? Type { get; set; }
    public SeriesStep? Step { get; set; }
    public IList<double>? Data { get; set; }
}

public enum SeriesType
{
    Line,
}

public enum SeriesStep
{
    Start,
    Middle,
    End,
}
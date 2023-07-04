namespace ECharts.Net;

public class XAxis
{
    public string? Id { get; set; }
    public AxisType? Type { get; set; }
    public IList<string>? Data { get; set; }
}

public enum AxisType
{
    Category,
    Value,
    Time,
    Log
}

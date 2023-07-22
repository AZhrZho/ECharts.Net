namespace ECharts.Net;

public class Dimension
{
    public string? Name { get; set; }
    public DimensionDataType? Type { get; set; }
    public string? DisplayName { get; set; }

    public static implicit operator Dimension(string name)
    {
        return new Dimension { Name = name };
    }
}

public enum DimensionDataType
{
    Number,
    Ordinal,
    Float,
    Int,
    Time
}

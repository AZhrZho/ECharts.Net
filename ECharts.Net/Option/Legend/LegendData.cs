using ECharts.Net.Util;

namespace ECharts.Net;

public class LegendData
{
    public string? Name { get; set; }
    public Intersected<Symbol, Uri>? Icon { get; set; }
    public Intersected<Value, ItemStyle>? ItemStyle { get; set; }
    public Intersected<Value, ItemStyle>? LineStyle { get; set; }
    public Intersected<Value, double>? SymbolRotate { get; set; }
    public TextStyle? TextStyle { get; set; }

    public static implicit operator LegendData(string name)
    {
        return new LegendData { Name = name };
    }
}

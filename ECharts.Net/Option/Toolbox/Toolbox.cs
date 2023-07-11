using ECharts.Net.Util;

namespace ECharts.Net;

public class Toolbox
{
    public string? Id { get; set; }
    public bool? Show { get; set; }
    public Orientation? Orient { get; set; }
    public double? ItemSize { get; set; }
    public double? ItemGap { get; set; }
    public bool? ShowTitle { get; set; }
    public Intersected<Feature, object> Feature { get; set; }
    public IconStyle? IconStyle { get; set; }
    // TODO: Toolbox.Emphasis
    public int? ZLevel { get; set; }
    public int? Z { get; set; }
    public Intersected<string, double>? Left { get; set; }
    public Intersected<string, double>? Top { get; set; }
    public Intersected<string, double>? Right { get; set; }
    public Intersected<string, double>? Bottom { get; set; }
    public Intersected<string, double>? Width { get; set; }
    public Intersected<string, double>? Height { get; set; }
    public Tooltip? Tooltip { get; set; }
}

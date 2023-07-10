using ECharts.Net.Util;

namespace ECharts.Net;

public class Grid
{
    public string? Id { get; set; }
    public bool? Show { get; set; }
    public int? ZLevel { get; set; }
    public int? Z { get; set; }
    public Intersected<string, double>? Left { get; set; }
    public Intersected<string, double>? Top { get; set; }
    public Intersected<string, double>? Right { get; set; }
    public Intersected<string, double>? Bottom { get; set; }
    public Intersected<string, double>? Width { get; set; }
    public Intersected<string, double>? Height { get; set; }
    public bool? ContainLabel { get; set; }
    public Color? BackgroudColor { get; set; }
    public Color? BorderColor { get; set; }
    public double? BorderWidth { get; set; }
    public double? ShadowBlur { get; set; }
    public Color? ShadowColor { get; set; }
    public double? ShadowOffsetX { get; set; }
    public double? ShadowOffsetY { get; set; }
    public Tooltip? Tooltip { get; set; }
}

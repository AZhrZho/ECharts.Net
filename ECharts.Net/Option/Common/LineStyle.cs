using ECharts.Net.Util;

namespace ECharts.Net;

public class LineStyle
{
    public Intersected<Value, EChartsColor>? Color { get; set; }
    public Intersected<Value, double>? Width { get; set; }
    public Intersected<BorderType, double, double[]>? Type { get; set; }
    public double? DashOffset { get; set; }
    public LineCap? Cap { get; set; }
    public LineJoin? Join { get; set; }
    public double? MiterLimit { get; set; }
    public double? ShadowBlur { get; set; }
    public EChartsColor? ShadowColor { get; set; }
    public double? ShadowOffsetX { get; set; }
    public double? ShadowOffsetY { get; set; }
    public double? Opacity { get; set; }
}

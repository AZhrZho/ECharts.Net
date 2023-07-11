using ECharts.Net.Util;

namespace ECharts.Net;

public class IconStyle
{
    public Intersected<Value, Color>? Color { get; set; }
    public Intersected<Value, Color>? BorderColor { get; set; }
    public Intersected<Value, double>? BorderWidth { get; set; }
    public Intersected<BorderType, double, double[]>? BorderType { get; set; }
    public double? BorderDashOffset { get; set; }
    public LineCap? BorderCap { get; set; }
    public LineJoin? BorderJoin { get; set; }
    public double? BorderMiterLimit { get; set; }
    public double? ShadowBlur { get; set; }
    public double? ShadowOffsetX { get; set; }
    public double? ShadowOffsetY { get; set; }
    public double? Opacity { get; set; }
}

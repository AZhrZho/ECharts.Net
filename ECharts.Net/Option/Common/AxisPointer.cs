using ECharts.Net.Util;

namespace ECharts.Net;

public class AxisPointer
{
    public PointerType? Type { get; set; }
    public AxisName? Axis { get; set; }
    public bool? Snap { get; set; }
    public int? Z { get; set; }
    public AxisPointerLabel? Label { get; set; }
    public LineStyle? LineStyle { get; set; }
    public ShadowStyle? ShadowStyle { get; set; }
    public CrossStyle? CrossStyle { get; set; }
    public bool? Animation { get; set; }
    public int? AnimationThreshold { get; set; }
    public int? AnimationDuration { get; set; }
    public string? AnimationEasing { get; set; }
    public Intersected<double, JsFunc<int, double>>? AnimationDelay { get; set; }
    public Intersected<double, JsFunc<int, double>>? AnimationDurationUpdate { get; set; }
    public string? AnimationEasingUpdate { get; set; }
    public Intersected<double, JsFunc<int, double>>? AnimationDelayUpdate { get; set; }
}

public class AxisPointerLabel : TextStyle
{
    public bool? Show { get; set; }
    public int? Precision { get; set; }
    // TODO: Support function of AxisPointerLabel.Formatter
    public string? Formatter { get; set; }
    public double? Margin { get; set; }
    public Thickness? Padding { get; set; }
    public EChartsColor? BackgroundColor { get; set; }
    public EChartsColor? BorderColor { get; set; }
    public double? BorderWidth { get; set; }
    public double? ShadowBlur { get; set; }
    public EChartsColor? ShadowColor { get; set; }
    public double? ShadowOffsetX { get; set; }
    public double? ShadowOffsetY { get; set; }
}

public class ShadowStyle
{
    public EChartsColor? Color { get; set; }
    public double? ShadowBlur { get; set; }
    public EChartsColor? ShadowColor { get; set; }
    public double? ShadowOffsetX { get; set; }
    public double? ShadowOffsetY { get; set; }
    public double? Opacity { get; set; }
}

public class CrossStyle
{
    public EChartsColor? Color { get; set; }
    public double? Width { get; set; }
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

public enum PointerType
{
    Line,
    Shadow,
    None,
    Cross
}

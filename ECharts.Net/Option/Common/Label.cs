using ECharts.Net.Util;

namespace ECharts.Net;

public class Label
{
    public bool? Show { get; set; }
    public Intersected<string, IList<Intersected<double, string>>>? Position { get; set; }
    public double? Distance { get; set; }
    public double? Rotate { get; set; }
    public IList<double>? Offset { get; set; }
    public string? Formatter { get; set; }
    public EChartsColor? Color { get; set; }
    public FontStyle? FontStyle { get; set; }
    public FontWeight? FontWeight { get; set; }
    public string? FontFamily { get; set; }
    public double? FontSize { get; set; }
    public HorizontalAlignment? Align { get; set; }
    public VerticalAlignment? VerticalAlign { get; set; }
    public double? LineHeight { get; set; }
    public Intersected<EChartsColor, object>? BackgroundColor { get; set; }
    public EChartsColor? BorderColor { get; set; }
    public double? BorderWidth { get; set; }
    public Intersected<BorderType, double, IList<double>>? BorderType { get; set; }
    public double? BorderDashOffset { get; set; }
    public Thickness? BorderRadius { get; set; }
    public Thickness? Padding { get; set; }
    public EChartsColor? ShadowColor { get; set; }
    public double? ShadowBlur { get; set; }
    public double? ShadowOffsetX { get; set; }
    public double? ShadowOffsetY { get; set; }
    public double? Width { get; set; }
    public double? Height { get; set; }
    public EChartsColor? TextBorderColor { get; set; }
    public double? TextBorderWidth { get; set; }
    public Intersected<BorderType, double, IList<double>>? TextBorderType { get; set; }
    public double? TextBorderDashOffset { get; set; }
    public EChartsColor? TextShadowColor { get; set; }
    public double? TextShadowBlur { get; set; }
    public double? TextShadowOffsetX { get; set; }
    public double? TextShadowOffsetY { get; set; }
    public TextOverflowBehavior? Overflow { get; set; }
    public string? Ellipsis { get; set; }
    public object? Rich { get; set; }
}

// TODO: Support Function
public class LabelLayout
{
    public bool? HideOverlap { get; set; }
    public bool? MoveOverlap { get; set; }
    public Intersected<double, string>? X { get; set; }
    public Intersected<double, string>? Y { get; set; }
    public double? Dx { get; set; }
    public double? Dy { get; set; }
    public double? Rotate { get; set; }
    public HorizontalAlignment? Align { get; set; }
    public VerticalAlignment? VerticalAlign { get; set; }
    public double? FontSize { get; set; }
    public bool? Draggable { get; set; }
    // LabelLinePoints
}

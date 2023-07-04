namespace ECharts.Net;

public class TitleTextStyle
{
    public Color? Color { get; set; }
    public FontStyle? FontStyle { get; set; }
    public FontWeight? FontWeight { get; set; }
    public string? FontFamily { get; set; }
    public double? FontSize { get; set; }
    public double? LineHeight { get; set; }
    public double? Width { get; set; }
    public double? Height { get; set; }
    public Color? TextBorderColor { get; set; }
    public double? TextBorderWidth { get; set; }
    // TODO: support number and array TextBorderType
    public BorderType? TextBorderType { get; set; }
    public double? TextBorderDashOffset { get; set; }
    public Color? TextShadowColor { get; set; }
    public double? TextShadowBlur { get; set; }
    public double? TextShadowOffsetX { get; set; }
    public double? TextShadowOffsetY { get; set; }
    public TextOverflowBehavior? Overflow { get; set; }
    public string? Ellipsis { get; set; }
    // TODO: support rich text style 
    // https://echarts.apache.org/zh/option.html#title.subtextStyle.rich.%3Cstyle_name%3E
    public dynamic? Rich { get; set; }
}

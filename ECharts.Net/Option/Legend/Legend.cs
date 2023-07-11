using ECharts.Net.Util;

namespace ECharts.Net;

public class Legend
{
    public LegendType? Type { get; set; }
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
    public Orientation? Orient { get; set; }
    public HorizontalAlignment? Align { get; set; }
    public Thickness? Padding { get; set; }
    public double? ItemGap { get; set; }
    public double? ItemWidth { get; set; }
    public double? ItemHeight { get; set; }
    public Intersected<Value, ItemStyle>? ItemStyle { get; set; }
    public Intersected<Value, LineStyle>? LineStyle { get; set; }
    public Intersected<Value, double>? SymbolRotate { get; set; }

    // TODO: support Function for Formatter
    public string? Formatter { get; set; }
    public Intersected<SelectMode, bool>? SelectedMode { get; set; }
    public Color? InactiveColor { get; set; }
    public Color? InactiveBorderColor { get; set; }
    public Intersected<Value, string> InactiveBorderWidth { get; set; }

    /// <summary>
    /// State table of selected legend.
    /// <br/>
    /// example:
    /// <br/>
    /// <code>
    /// selected: {
    ///   // selected 'series 1'
    ///   'series 1': true,
    ///   // unselected 'series 2'
    ///   'series 2': false
    /// }
    /// </code>
    /// See also: <seealso href="https://echarts.apache.org/en/option.html#legend.selected"/>
    /// </summary>
    public dynamic? Selected { get; set; }
    public LegendTextStyle? TextStyle { get; set; }
    public Tooltip? Tooltip { get; set; }
    public Intersected<Symbol, Uri>? Icon { get; set; }
}


public enum LegendType
{
    Plain,
    Scroll
}
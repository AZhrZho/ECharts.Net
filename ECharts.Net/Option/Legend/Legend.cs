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
    public IList<LegendData>? Data { get; set; }
    public Color? BackgroundColor { get; set; }
    public Color? BorderColor { get; set; }
    public double? BorderWidth { get; set; }
    public double? BorderRadius { get; set; }
    public double? ShadowBlur { get; set; }
    public Color? ShadowColor { get; set; }
    public double? ShadowOffsetX { get; set; }
    public double? ShadowOffsetY { get; set; }
    public int? ScrollDataIndex { get; set; }
    public double? PageButtonItemGap { get; set; }
    public double? PageButtonGap { get; set; }
    public Position? PageButtonPosition { get; set; }
    public string? PageFormatter { get; set; }
    public PageIcon? PageIcons { get; set; }
    public Color? PageIconColor { get; set; }
    public Color? PageIconInactiveColor { get; set; }
    public Intersected<double, IList<double>> PageIconSize { get; set; }
    public TextStyle? PageTextStyle { get; set; }
    public bool? Animation { get; set; }
    public double? AnimationDurationUpdate { get; set; }
    public LegendEmphasis? Emphasis { get; set; }
    public Intersected<bool, IList<LegendSelectorType>, IList<LegendSelector>> Selector { get; set; }
    // TODO: Legend.SelectorLabel
    public Position? SelectorPosition { get; set; }
    public double? SelectorItemGap { get; set; }
    public double? SelectorButtonGap { get; set; }
}

public class LegendEmphasis
{
    // TODO implement Legend.Emphasis
}

public enum LegendType
{
    Plain,
    Scroll
}

public struct PageIcon
{
    public IList<Intersected<string, Uri>> Horizontal { get; set; }
    public IList<Intersected<string, Uri>> Vertical { get; set; }
}

public struct LegendSelector
{
    public LegendSelectorType? Type { get; set; }
    public string? Title { get; set; }
}

public enum LegendSelectorType
{
    All,
    Inverse
}
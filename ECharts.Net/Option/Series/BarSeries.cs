namespace ECharts.Net;

using System.Collections.Generic;
using ECharts.Net.Util;
using static ECharts.Net.LineSeries;
using BarSeriesData = Util.Intersected<IList<double>, IList<string>, IList<IList<Util.Intersected<double, string>>>>;

public partial class BarSeries : Series
{
    public BarSeries() => this.Type = SeriesType.Bar;
    public int? XAxisIndex { get; set; }
    public int? YAxisIndex { get; set; }
    public int? PolarIndex { get; set; }
    public bool? RoundCap { get; set; }
    public bool? RealtimeSort { get; set; }
    public bool? ShowBackground { get; set; }
    public BarSeriesBackgroundStyle? BackgroundStyle { get; set; }
    public Label? Label { get; set; }
    public BarSeriesLabelLine? LabelLine { get; set; }
    public ItemStyle? ItemStyle { get; set; }
    // LabelLayout
    public BarSeriesEmphasis? Emphasis { get; set; }
    public BarSeriesStyle? Blur { get; set; }
    public BarSeriesSelect? Select { get; set; }
    public Intersected<SelectMode, bool>? SelectedMode { get; set; }
    public string? Stack { get; set; }
    public SeriesStackStrategy? StackStrategy { get; set; }
    public SeriesSampling? Sampling { get; set; }
    public string? Cursor { get; set; }
    public Intersected<double, string> BarWidth { get; set; }
    public Intersected<double, string> BarMaxWidth { get; set; }
    public Intersected<double, string> BarMinWidth { get; set; }
    public double BarMinHeight { get; set; }
    public double BarMinAngle { get; set; }
    public string? BarGap { get; set; }
    public string? BarCategoryGap { get; set; }
    public bool? Large { get; set; }
    public int? LargeThreshold { get; set; }
    public int? Progressive { get; set; }
    public int? ProgressiveThreshold { get; set; }
    public ProgressiveChunkMode? ProgressiveChunkMode { get; set; }
    public IList<Dimension?>? Dimensions { get; set; }
    public object? Encode { get; set; }
    public string? SeriesLayoutBy { get; set; }
    public int? DatasetIndex { get; set; }
    public int? DataGroupId { get; set; }
    public new BarSeriesData? Data { get; set; }
    // MarkPoint
    // MarkLine
    // MarkArea
    // UniversalTransition
    // Tooltip
}

public partial class BarSeries
{
    public class BarSeriesBackgroundStyle
    {
        public EChartsColor? Color { get; set; }
        public EChartsColor? BorderColor { get; set; }
        public double? BorderWidth { get; set; }
        public BorderType? BorderType { get; set; }
        public double? BorderRadius { get; set; }
        public double? ShadowBlur { get; set; }
        public EChartsColor? ShadowColor { get; set; }
        public double? ShadowOffsetX { get; set; }
        public double? ShadowOffsetY { get; set; }
        public double? Opacity { get; set; }
    }

    public class BarSeriesLabelLine
    {
        public bool? Show { get; set; }
        public LineStyle? LineStyle { get; set; }
    }

    public class BarSeriesEmphasis : BarSeriesStyle
    {
        public bool? Disabled { get; set; }
        public FocusType? Focus { get; set; }
        public BlurScope? BlurScope { get; set; }
    }

    public class BarSeriesSelect : BarSeriesStyle
    {
        public bool? Disabled { get; set; }
    }

    public class BarSeriesStyle
    {
        public Label? Label { get; set; }
        public BarSeriesLabelLine? LabelLine { get; set; }
        public ItemStyle? ItemStyle { get; set; }
    }
}


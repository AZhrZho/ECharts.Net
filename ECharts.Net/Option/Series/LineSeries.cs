using ECharts.Net.Util;

namespace ECharts.Net;

using LineSeriesData = Intersected<IList<double>, IList<string>, IList<IList<Intersected<double, string>>>>;

public partial class LineSeries : Series
{
    public LineSeries() 
    { 
        Type = SeriesType.Line;
    }

    public int? XAxisIndex { get; set; }
    public int? YAxisIndex { get; set; }
    public int? PolarIndex { get; set; }
    // TODO Support Func for Symbol
    public Intersected<SeriesSymbol, Uri>? Symbol { get; set; }
    // TODO Support Array | Function SymbolSize
    public double? SymbolSize { get; set; }
    public double? SymbolRotate { get; set; }
    public bool? SymbolKeepAspect { get; set; }
    // SymbolOffset
    public bool? ShowSymbol { get; set; }
    public bool? ShowAllSymbol { get; set; }
    public bool? LegendHoverLink { get; set; }
    public string? Stack { get; set; }
    public SeriesStackStrategy? StackStrategy { get; set; }
    public string? Cursor { get; set; }
    public bool? ConnectNulls { get; set; }
    public bool? TriggerLineEvent { get; set; }
    public SeriesStep? Step { get; set; }
    // Label
    // EndLabel
    // LabelLine
    // LabelLayout
    // ItemStyle
    // LineStyle
    public SeriesAreaStyle? AreaStyle { get; set; }
    // Emphasis
    // Select
    public bool? SelectedMode { get; set; }
    public Intersected<bool, double>? Smooth { get;set; }
    public SeriesSmoothMonotone? SmoothMonotone { get; set; }
    public SeriesSampling? Sampling { get; set; }
    // Dimensions
    // Encode
    // TODO Make SeriesLayoutBy Enum
    public string? SeriesLayoutBy { get; set; }
    public int? DatasetIndex { get; set; }
    public int? DataGroupId { get; set; }
    public new LineSeriesData? Data { get; set; }
    // MarkPoint
    // MarkLine
    // MarkArea

    public enum SeriesStep
    {
        Start,
        Middle,
        End,
    }
}

public partial class LineSeries
{
    public class SeriesAreaStyle
    {
        public Color? Color { get; set; }
        public Intersected<AreaOrigin, double>? Origin { get; set; }
        public double? ShadowBlur { get; set; }
        public Color? ShadowColor { get; set; }
        public double? ShadowOffsetX { get; set; }
        public double? ShadowOffsetY { get; set; }
        public double? Opacity { get; set; }
    }

    public enum AreaOrigin
    {
        Auto,
        Start,
        End
    }
}
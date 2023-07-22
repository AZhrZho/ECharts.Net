using ECharts.Net.Util;

namespace ECharts.Net;

using LineSeriesData = Intersected<IList<double>, IList<string>, IList<IList<Intersected<double, string>>>>;
using LineSeriesSymbolOffset = Intersected<IList<double>, IList<string>, IList<Intersected<double, string>>>;

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
    public Intersected<Symbol, Uri>? Symbol { get; set; }
    // TODO Support Array | Function SymbolSize
    public double? SymbolSize { get; set; }
    public double? SymbolRotate { get; set; }
    public bool? SymbolKeepAspect { get; set; }
    public LineSeriesSymbolOffset? SymbolOffset { get; set; }
    public bool? ShowSymbol { get; set; }
    public bool? ShowAllSymbol { get; set; }
    public bool? LegendHoverLink { get; set; }
    public string? Stack { get; set; }
    public SeriesStackStrategy? StackStrategy { get; set; }
    public string? Cursor { get; set; }
    public bool? ConnectNulls { get; set; }
    public bool? TriggerLineEvent { get; set; }
    public SeriesStep? Step { get; set; }
    public Label? Label { get; set; }
    public LineSeriesEndLabel? EndLabel { get; set; }
    public LineSeriesLabelLine? LabelLine { get; set; }
    public LabelLayout? LabelLayout { get; set; }
    public ItemStyle? ItemStyle { get; set; }
    public LineStyle? LineStyle { get; set; }
    public LineSeriesAreaStyle? AreaStyle { get; set; }
    public LineSeriesEmphasis? Emphasis { get; set; }
    public LineSeriesSelect? Select { get; set; }
    public Intersected<SelectMode, bool>? SelectedMode { get; set; }
    public Intersected<bool, double>? Smooth { get;set; }
    public SeriesSmoothMonotone? SmoothMonotone { get; set; }
    public SeriesSampling? Sampling { get; set; }
    public IList<Dimension?>? Dimensions { get; set; }
    // TODO Support typed Encode
    public object? Encode { get; set; }
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
    public class LineSeriesAreaStyle
    {
        public EChartsColor? Color { get; set; }
        public Intersected<AreaOrigin, double>? Origin { get; set; }
        public double? ShadowBlur { get; set; }
        public EChartsColor? ShadowColor { get; set; }
        public double? ShadowOffsetX { get; set; }
        public double? ShadowOffsetY { get; set; }
        public double? Opacity { get; set; }
    }

    public class LineSeriesEmphasis
    {
        public bool? Disabled { get; set; }
        public Intersected<bool, double>? Scale { get; set; }
        public FocusType? Focus { get; set; }
        public BlurScope? BlurScope { get; set; }
        public Label? Label { get; set; }
        public LineSeriesEndLabel? EndLabel { get; set; }
        public ItemStyle? ItemStyle { get; set; }
        public LineStyle? LineStyle { get; set; }
        public LineSeriesAreaStyle? AreaStyle { get; set; }

    }

    public class LineSeriesEndLabel : Label
    {
        [JsonIgnore]
        protected new Intersected<string, IList<Intersected<double, string>>>? Position { get; set; }
        public bool? ValueAnimation { get; set; }
    }

    public class LineSeriesLabelLine
    {
        public bool? Show { get; set; }
        public bool? ShowAbove { get; set; }
        public double? Length2 { get; set; }
        public Intersected<bool, double> Smooth { get; set; }
        public double? MinTurnAngle { get; set; }
        public LineStyle? LineStyle { get; set; }
    }

    public class LineSeriesSelect
    {
        public bool? Disabled { get; set; }
        public Label? Label { get; set; }
        public LineSeriesLabelLine? LabelLine { get; set; }
        public ItemStyle? ItemStyle { get; set; }
        public LineStyle? LineStyle { get; set; }
        public LineSeriesAreaStyle? AreaStyle { get; set; }
        public LineSeriesEndLabel? EndLabel { get; set; }
    }

    public enum AreaOrigin
    {
        Auto,
        Start,
        End
    }

    public enum FocusType
    {
        None,
        Self,
        Series
    }

    public enum BlurScope
    {
        CoordinateSystem,
        Series,
        Global
    }
}
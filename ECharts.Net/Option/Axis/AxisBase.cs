using ECharts.Net.Util;

namespace ECharts.Net.Internal;

public abstract class AxisBase
{
    public string? Id { get; set; }
    public bool? Show { get; set; }
    public int? GridIndex { get; set; }
    public bool? AlignTicks { get; set; }
    public double? Offset { get; set; }
    public AxisType? Type { get; set; }
    public string? Name { get; set; }
    public AxisNameLocation? NameLocation { get; set; }
    // NameTextStyle
    public double? NameGap { get; set; }
    public double? NameRotate { get; set; }
    public bool? Inverse { get; set; }
    public Intersected<bool, Intersected<IList<double>, IList<string>, IList<object>>>? BoundaryGap { get; set; }
    // TODO: Add function support for XAxis.Min
    public Intersected<double, string>? Min { get; set; }
    // TODO: Add function support for XAxis.Max
    public Intersected<double, string>? Max { get; set; }
    public bool? Scale { get; set; }
    public int? SplitNumber { get; set; }
    public double? MinInterval { get; set; }
    public double? MaxInterval { get; set; }
    public double? Interval { get; set; }
    public double? LogBase { get; set; }
    public bool? Silent { get; set; }
    public bool? TriggerEvent { get; set; }
    public AxisLine? AxisLine { get; set; }
    public AxisTick? AxisTick { get; set; }
    // MinorTick
    public AxisLabel? AxisLabel { get; set; }
    public AxisSplitLine? SplitLine { get; set; }
    // MinorSplitLine
    public AxisSplitArea? SplitArea { get; set; }
    // TODO: Support Data.TextStyle
    public IList<string>? Data { get; set; }
    // AxisPointer
    public bool? Animation { get; set; }
    public int? AnimationThreshold { get; set; }
    public int? AnimationDuration { get; set; }
    public string? AnimationEasing { get; set; }
    public Intersected<double, JsFunc<int, double>>? AnimationDelay { get; set; }
    public Intersected<double, JsFunc<int, double>>? AnimationDurationUpdate { get; set; }
    public string? AnimationEasingUpdate { get; set; }
    public Intersected<double, JsFunc<int, double>>? AnimationDelayUpdate { get; set; }
    public int? ZLevel { get; set; }
    public int? Z { get; set; }
}

public class AxisLine
{
    public bool? Show { get; set; }
    public bool? OnZero { get; set; }
    public int? OnZeroAxisIndex { get; set; }
    public Intersected<string, IList<string>>? Symbol { get; set; }
    public Intersected<double, IList<double>>? SymbolSize { get; set; }
    public Intersected<double, IList<double>>? SymbolOffset { get; set; }
    public LineStyle? LineStyle { get; set; }
}

public class AxisTick
{
    public bool? Show { get; set; }
    public bool? AlignWithLabel { get; set; }
    public bool? Inside { get; set; }
    public double? Length { get; set; }
    public LineStyle? LineStyle { get; set; }
    public double? Interval { get; set; }
}

public class AxisSplitLine
{
    public bool? Show { get; set; }
    public double? Interval { get; set; }
    public LineStyle? LineStyle { get; set; }
}

public class AxisSplitArea
{
    public bool? Show { get; set; }
    public double? Interval { get; set; }
    public AxisAreaStyle? AreaStyle { get; set; }
}

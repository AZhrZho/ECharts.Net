using ECharts.Net.Util;

namespace ECharts.Net;

public class XAxis
{
    public string? Id { get; set; }
    public bool? Show { get; set; }
    public int? GridIndex { get; set; }
    public bool? AlignTicks { get; set; }
    public XAxisPosition? Position { get; set; }
    public double? Offset { get; set; }
    public AxisType? Type { get; set; }
    public string? Name { get; set; }
    public XAxisNameLocation? NameLocation { get; set; }
    // NameTextStyle
    public double? NameGap { get; set; }
    public double? NameRotate { get; set; }
    public bool? Inverse { get; set; }
    public Intersected<bool, Intersected<IList<double>, IList<string>, IList<object>>> BoundaryGap { get; set; }
    // TODO: Add function support for XAxis.Min
    public Intersected<double, string> Min { get; set; }
    // TODO: Add function support for XAxis.Max
    public Intersected<double, string> Max { get; set; }
    public bool? Scale { get; set; }
    public int? SplitNumber { get; set; }
    public double? MinInterval { get; set; }
    public double? MaxInterval { get; set; }
    public double? Interval { get; set; }
    public double? LogBase { get; set; }
    public bool? Silent { get; set; }
    public bool? TriggerEvent { get; set; }
    // AxisLine
    // AxisTick
    // MinorTick
    // AxisLabel
    // SplitLine
    // MinorSplitLine
    // SplitArea
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

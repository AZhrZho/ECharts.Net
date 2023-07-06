using ECharts.Net.Util;
using System.Collections;

namespace ECharts.Net;

public class Series
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public SeriesType? Type { get; set; }
    
    public IList? Data { get; set; }

    public bool? Clip { get; set; }
    public bool? Silent { get; set; }
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

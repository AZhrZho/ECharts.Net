﻿using ECharts.Net.Util;

namespace ECharts.Net;

public class LegendTextStyle :TextStyle
{
    public EChartsColor? BackgroundColor { get; set; }
    public EChartsColor? BorderColor { get; set; }
    public double? BorderWidth { get; set; }
    public Intersected<BorderType, double, double[]>? BorderType { get; set; }
    public double? BorderDashOffset { get; set; }
    public double? BorderRadius { get; set; }
    public Thickness? Padding { get; set; }
    public EChartsColor? ShadowColor { get; set; }
    public double? ShadowBlur { get; set; }
    public double? ShadowOffsetX { get; set; }
    public double? ShadowOffsetY { get; set; }
}

using ECharts.Net.Util;

using SymbolType = ECharts.Net.Util.Intersected<ECharts.Net.Symbol, System.Uri, System.Collections.Generic.IList<ECharts.Net.Util.Intersected<ECharts.Net.Symbol, System.Uri>>>;
using DashArrayType = ECharts.Net.Util.Intersected<double, System.Collections.Generic.IList<double>, System.Collections.Generic.IList<ECharts.Net.Util.Intersected<double, System.Collections.Generic.IList<double>>>>;

namespace ECharts.Net;

public class ItemStyle
{
    public Intersected<Value, Color>? Color { get; set; }
    public Intersected<Value, Color>? BorderColor { get; set; }
    public Intersected<Value, double>? BorderWidth { get; set; }
    public Intersected<BorderType, double, double[]>? BorderType { get; set; }
    public double? BorderDashOffset { get; set; }
    public LineCap? BorderCap { get; set; }
    public LineJoin? BorderJoin { get; set; }
    public double? BorderMiterLimit { get; set; }
    public double? ShadowBlur { get; set; }
    public double? ShadowOffsetX { get; set; }
    public double? ShadowOffsetY { get; set; }
    public double? Opacity { get; set; }
    public ItemDecal? Decal { get; set; }
}

public class ItemDecal
{
    public SymbolType? Symbol { get; set; }
    public double? SymbolSize { get; set; }
    public bool? SymbolKeepAspect { get; set; }
    public Color? Color { get; set; }
    public Color? BorderColor { get; set; }
    public DashArrayType? DashArrayX { get; set; }
    public DashArrayType? DashArrayY { get; set; }
    public double? Rotation { get; set; }
    public double? MaxTileWidth { get; set; }
    public double? MaxTileHeight { get; set; }
}
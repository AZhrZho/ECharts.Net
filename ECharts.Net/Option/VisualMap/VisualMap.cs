using ECharts.Net.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECharts.Net
{
    public abstract class VisualMap
    {
        public VisualMapType? Type { get; set; }
        public string? Id { get; set; }

        public double? Min {  get; set; }
        public double? Max { get; set; }
        public bool? Inverse { get; set; }
        public int? Precision { get; set; }
        public double? ItemWidth { get; set; }
        public double? ItemHeight { get; set; }
        public IList<string>? Text { get; set; }
        public double? TextGap { get; set; }
        public bool? Show {  get; set; }
        public int? Dimension { get; set; }
        public Intersected<int, IList<int>>? SeriesIndex { get; set; }
        public bool? HoverLink { get; set; }

        public Range? InRange { get; set; }
        public Range? OutOfRange { get; set; }
        public RangeContainer? Target { get; set; }
        public RangeContainer? Controller { get; set; }

        public int? Zlevel { get; set; }
        public int? Z { get; set; }
        public Intersected<string, double, HorizontalAlignment>? Left { get; set; }
        public Intersected<string, double, VerticalAlignment>? Top { get; set; }
        public Intersected<string, double>? Right { get; set; }
        public Intersected<string, double>? Bottom { get; set; }
        public Orientation? Orient { get; set; }
        public Thickness? Padding { get; set; }
        public EChartsColor? BackgroundColor { get; set; }
        public EChartsColor? BorderColor { get; set; }
        public double? BorderWidth { get; set; }
        public TextStyle? TextStyle { get; set; }
        public string? Formatter { get; set; }
    }
}

public enum VisualMapType
{
    Continuous,
    Piecewise
}

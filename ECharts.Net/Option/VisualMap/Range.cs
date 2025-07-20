using ECharts.Net.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECharts.Net
{
    public class Range
    {
        public Intersected<Symbol, IList<Symbol>>? Symbol { get; set; }
        public Intersected<double, IList<double>>? SymbolSize { get; set; }
        public Intersected<EChartsColor, IList<EChartsColor>, object>? Color { get; set; }
        public Intersected<double, IList<double>>? ColorAlpha { get; set; }
        public Intersected<double, IList<double>>? Opacity { get; set; }
        public Intersected<double, IList<double>>? ColorLightness { get; set; }
        public Intersected<double, IList<double>>? ColorSaturation { get; set; }
        public Intersected<double, IList<double>>? ColorHue { get; set; }
    }

    public class RangeContainer
    {
        public Range? InRange { get; set; }
        public Range? OutOfRange { get; set; }
    }

    public class RangeExtend: Range
    {
        public double? Min { get; set; }
        public double? Max { get; set; }
        public double? Value { get; set; }
        public string? Label { get; set; }
        public double? Lt { get; set; }
        public double? Gt { get; set; }
        public double? Lte { get; set; }
        public double? Gte { get; set; }
    }
}

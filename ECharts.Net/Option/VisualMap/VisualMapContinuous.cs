using ECharts.Net.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECharts.Net
{
    public class VisualMapContinuous: VisualMap
    {
        public VisualMapContinuous() => Type = VisualMapType.Continuous;

        public IList<int>? Range {  get; set; }
        public bool? Calculable { get; set; }
        public bool? Realtime { get; set; }
        public AlignFour? Align { get; set; }
        public string? HandleIcon { get; set; }
        public Intersected<double, string>? HandleSize { get; set; }
        public ItemStyle? HandleStyle { get; set; }
        public Symbol? IndicatorIcon { get; set; }
        public Intersected<double, string>? IndicatorSize { get; set; }
        public ItemStyle? IndicatorStyle { get; set; }
    }
}

using ECharts.Net.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECharts.Net
{
    public class VisualMapPiecewise: VisualMap
    {
        public VisualMapPiecewise() => Type = VisualMapType.Piecewise;
        /// <summary>
        /// 示例注释：
        /// <para>指定组件中图形（比如小方块）和文字的摆放关系，可选值为：</para>
        /// <list type="bullet">
        /// <item>
        /// <description><c>'auto'</c> 自动决定。</description>
        /// </item>
        /// <item>
        /// <description><c>'left'</c> 图形在左文字在右。</description>
        /// </item>
        /// <item>
        /// <description><c>'right'</c> 图形在右文字在左。</description>
        /// </item>
        /// </list>
        /// </summary>
        public AlignTwo? Align {  get; set; }
        public int? SplitNumber { get; set; }
        public IList<RangeExtend>? Pieces { get; set; }
        public IList<string>? Categories { get; set; }
        public bool? MinOpen { get; set; }
        public bool? MaxOpen { get; set; }
        public Intersected<SelectMode, bool>? SelectedMode { get; set; }
        public bool? ShowLabel { get; set; }
        public double? ItemGap { get; set; }
        public Symbol ItemSymbol { get; set; }
    }
}

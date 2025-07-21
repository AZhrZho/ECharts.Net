using ECharts.Net.Util;

namespace ECharts.Net;

public class Option
{
    public Intersected<Title, IList<Title>>? Title { get; set; }
    public Intersected<Legend, IList<Legend>>? Legend { get; set; }
    public Intersected<VisualMap, IList<VisualMap>>? VisualMap { get; set; }
    public Intersected<Grid, IList<Grid>> Grid { get; set; }
    public Intersected<XAxis, IList<XAxis>> XAxis { get; set; }
    public Intersected<YAxis, IList<YAxis>> YAxis { get; set; }
    public Tooltip? Tooltip { get; set; }
    public Toolbox? Toolbox { get; set; }
    public IList<Series>? Series { get; set; }
    public IList<EChartsColor>? Color { get; set; }
}

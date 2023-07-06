using ECharts.Net.Util;

namespace ECharts.Net;

public class Option
{
    public Intersected<Title, IList<Title>>? Title { get; set; }
    public XAxis? XAxis { get; set; }
    public YAxis? YAxis { get; set; }
    public IList<Series>? Series { get; set; }
}

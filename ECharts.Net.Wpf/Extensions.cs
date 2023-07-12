using System.Windows.Media;

namespace ECharts.Net;

public static class Extensions
{
    public static SolidColor ToEChartColor(this Color color)
    {
        return new SolidColor() { A = color.A, R = color.R, G = color.G, B = color.B, };
    }
}

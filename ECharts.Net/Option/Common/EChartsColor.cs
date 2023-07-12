namespace ECharts.Net;

public abstract class EChartsColor
{
    public static implicit operator EChartsColor(Color color)
    {
        return new SolidColor() { A = color.A, R = color.R, G = color.G, B = color.B };
    }

    public static SolidColor Rgb(byte r, byte g, byte b)
    {
        return new SolidColor { A = 255, R = r, G= g, B = b };
    }

    public static SolidColor Hex(uint hex)
    {
        var r = (hex >> 16) & 0xFF;
        var g = (hex >> 8) & 0xFF;
        var b = hex & 0xFF;
        return Rgb((byte)r, (byte)g, (byte)b);
    }
}

public class SolidColor : EChartsColor
{
    public byte A { get; set; }
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    public uint ToArgb()
    {
        return (uint)(R << 16) | (uint)(G << 8) | B;
    }

    public static implicit operator SolidColor(Color color)
    {
        return new() { A = color.A, R = color.R, G = color.G, B = color.B };
    }
}

public class LinearGradientColor : EChartsColor
{
    public string Type { get; } = "linear";
    public double X { get; set; }
    public double Y { get; set; }
    public double X2 { get; set; }
    public double Y2 { get; set; }
    public IList<GradientColorStop>? ColorStops { get; set; }
    public bool? Global { get; set; }
}

public class RadialGradientColor : EChartsColor
{
    public string Type { get; } = "radial";
    public double X { get; set; }
    public double Y { get; set; }
    public double R { get; set; }
    public IList<GradientColorStop>? ColorStops { get; set; }
    public bool? Global { get; set; }
}

public class GradientColorStop
{
    public double Offset { get; set; }
    public SolidColor Color { get; set; } = null!;
}

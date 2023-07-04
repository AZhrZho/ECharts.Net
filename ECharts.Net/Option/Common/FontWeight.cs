namespace ECharts.Net;

public class FontWeight
{
    public FontWeight(int value)
    {
        Value = value;
    }

    public int Value { get; set; }

    public static implicit operator FontWeight(int value) => new(value);

    public static readonly FontWeight Thin = 100;
    public static readonly FontWeight Hairline = 100;
    public static readonly FontWeight ExtraLight = 200;
    public static readonly FontWeight UltraLight = 200;
    public static readonly FontWeight Light = 300;
    public static readonly FontWeight Normal = 400;
    public static readonly FontWeight Medium = 500;
    public static readonly FontWeight SemiBold = 600;
    public static readonly FontWeight DemiBild = 600;
    public static readonly FontWeight Bold = 700;
    public static readonly FontWeight ExtraBold = 800;
    public static readonly FontWeight Black = 900;
}

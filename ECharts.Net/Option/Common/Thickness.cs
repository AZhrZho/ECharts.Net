namespace ECharts.Net;

public struct Thickness
{
    public Thickness(double value)
    {
        Top = Right = Bottom = Left = value;
    }

    public Thickness(double vertical, double horizontal)
    {
        Top = Bottom = vertical;
        Left = Right = horizontal;
    }

    public Thickness(double top, double right, double bottom, double left)
    {
        Top = top;
        Right = right;
        Bottom = bottom;
        Left = left;
    }

    public double Top;
    public double Right;
    public double Bottom;
    public double Left;

    public static implicit operator Thickness(double value)
    {
        return new Thickness(value);
    }

    public static implicit operator Thickness((double vertical, double horizontal) value)
    {
        return new Thickness(value.vertical, value.horizontal);
    }

    public static implicit operator Thickness((double top, double right, double bottom, double left) value)
    {
        var (top, right, bottom, left) = value;
        return new Thickness(top, right, bottom, left);
    }
}

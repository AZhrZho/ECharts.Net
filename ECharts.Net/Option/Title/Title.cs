using ECharts.Net.Util;
using System.Drawing;

namespace ECharts.Net;

public class Title
{
    public string? Id { get; set; }
    public bool? Show { get; set; }
    public string? Text { get; set; }
    public string? Link { get; set; }
    public TitleTargetType? Target { get; set; }
    public TextStyle? TextStyle { get; set; }
    public string? Subtext { get; set; }
    public string? Sublink { get; set; }
    public TitleTargetType? Subtarget { get; set; }
    public TitleSubtextStyle? SubtextStyle { get; set; }
    public HorizontalAlignment? TextAlign { get; set; }
    public VerticalAlignment? TextVerticalAlign { get; set; }
    public bool? TriggerEvent { get; set; }
    public Thickness? Padding { get; set; }
    public double? ItemGap { get; set; }
    public int? ZLevel { get; set; }
    public int? Z { get; set; }
    public Intersected<string, double>? Left { get; set; }
    public Intersected<string, double>? Top { get; set; }
    public Intersected<string, double>? Right { get; set; }
    public Intersected<string, double>? Bottom { get; set; }
    public Color? BackgroundColor { get; set; }
    public Color? BorderColor { get; set; }
    public double? BorderWidth { get; set;}
    public Thickness? BorderRadius { get; set; }
    public double? ShadowBlur { get; set; }
    public Color? ShadowColor { get; set; }
    public double? ShadowOffsetX { get; set; }
    public double? ShadowOffsetY { get; set; }
}

public enum TitleTargetType
{
    Blank,
    Self
}

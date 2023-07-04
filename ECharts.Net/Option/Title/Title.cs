namespace ECharts.Net;

public class Title
{
    public string? Id { get; set; }
    public bool? Show { get; set; }
    public string? Text { get; set; }
    public string? Link { get; set; }
    public TitleTargetType? Target { get; set; }
    public TitleTextStyle? TextStyle { get; set; }
    public string? Subtext { get; set; }
    public string? Sublink { get; set; }
    public TitleTargetType? Subtarget { get; set; }
    public TitleSubtextStyle? SubtextStyle { get; set; }
    public HorizontalAlignment? TextAlign { get; set; }
    public VerticalAlignment? TextVerticalAlign { get; set; }
    public bool? TriggerEvent { get; set; }
}

public enum TitleTargetType
{
    Blank,
    Self
}

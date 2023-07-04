namespace ECharts.Net;

public class Title
{
    public string? Id { get; set; }
    public bool? Show { get; set; }
    public string? Text { get; set; }
    public string? Link { get; set; }
    public TitleTargetType? Target { get; set; }
    // TODO TextStyle
    public string? Subtext { get; set; }
    public string? Sublink { get; set; }
    public TitleTargetType? Subtarget { get; set; }
    // TODO Title.SubTextStyle

}

public enum TitleTargetType
{
    Blank,
    Self
}

public enum TextAlign
{
    Auto,
    Center,
    Right,
    Left,
}
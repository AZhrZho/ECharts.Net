namespace ECharts.Net;

public class Tooltip
{
    public bool? Show { get; set; }
    public TooltipTrigger? Trigger { get; set; }
    public AxisPointer? AxisPointer { get; set; }
    // TODO: Support Array|Function for Tooltip.Position
    public TooltipPosition? Position { get; set; }
    public string? Formatter { get; set; }
    public string? ValueFormatter { get; set; }
    public Color? BackgroundColor { get; set; }
    public Color? BorderColor { get; set; }
    public double? BorderWidth { get; set; }
    public Thickness? Padding { get; set; }
    public TextStyle? TextStyle { get; set; }
    public string? ExtraCssText { get; set; }
}

public enum TooltipTrigger
{
    None,
    Item,
    Axis
}

public enum TooltipPosition
{
    Inside,
    Top,
    Bottom,
    Left,
    Right
}
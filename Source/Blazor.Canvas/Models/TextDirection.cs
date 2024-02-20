namespace Blazor.Canvas.Models;
/// <summary>
/// The CanvasRenderingContext2D.direction property of the Canvas 2D API specifies the current text direction used to draw text.
/// </summary>
public record TextDirection
{
    internal TextDirection() { }
    internal string? Value { get; init; }
    /// <summary>
    /// The text direction is inherited from the canvas element or the Document as appropriate. Default value.
    /// </summary>
    public static TextDirection Inherit {get;} = new()
    {
        Value = "inherit",
    };
    /// <summary>
    /// The text direction is left-to-right.
    /// </summary>
    public static TextDirection LeftToRight {get;} = new()
    {
        Value = "ltr",
    };
    /// <summary>
    /// The text direction is right-to-left.
    /// </summary>
    public static TextDirection RightToLeft {get;} = new()
    {
        Value = "rtl",
    };
}

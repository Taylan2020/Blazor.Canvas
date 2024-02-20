namespace Blazor.Canvas.Models;
/// <summary>
/// The CanvasRenderingContext2D.textAlign property of the Canvas 2D API specifies the current text alignment used when drawing text.
///
/// The alignment is relative to the x value of the fillText() method.For example, if textAlign is "center", then the text's left edge will be at x - (textWidth / 2).
/// </summary>
public record TextAlign
{
    internal TextAlign() { }
    internal string? Value { get; init; }
    /// <summary>
    /// The text is aligned at the normal start of the line (left-aligned for left-to-right locales, right-aligned for right-to-left locales).
    /// </summary>
    public static TextAlign Start {get;} = new()
    {
        Value = "start",
    };
    /// <summary>
    /// The text is aligned at the normal end of the line (right-aligned for left-to-right locales, left-aligned for right-to-left locales).
    /// </summary>
    public static TextAlign End {get;} = new()
    {
        Value = "end",
    };
    /// <summary>
    /// The text is left-aligned.
    /// </summary>
    public static TextAlign Left {get;} = new()
    {
        Value = "left",
    };
    /// <summary>
    /// The text is right-aligned.
    /// </summary>
    public static TextAlign Right {get;} = new()
    {
        Value = "right",
    };
    /// <summary>
    /// The text is centered.
    /// </summary>
    public static TextAlign Center {get;} = new()
    {
        Value = "center",
    };
}

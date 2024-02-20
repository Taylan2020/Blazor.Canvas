namespace Blazor.Canvas.Models;
/// <summary>
/// The CanvasRenderingContext2D.fontKerning property of the Canvas API specifies how font kerning information is used. Kerning adjusts how adjacent letters are spaced in a proportional font, allowing them to edge into each other's visual area if there is space available. For example, in well-kerned fonts, the characters AV, Ta and We nest together and make character spacing more uniform and pleasant to read than the equivalent text without kerning.
/// </summary>
public record FontKerning
{
    internal FontKerning() { }
    internal string? Value { get; init; }
    /// <summary>
    /// The browser determines whether font kerning should be used or not. For example, some browsers will disable kerning on small fonts, since applying it could harm the readability of text.
    /// </summary>
    public static FontKerning Auto {get;} = new()
    {
        Value = "auto",
    };
    /// <summary>
    /// Font kerning information stored in the font must be applied.
    /// </summary>
    public static FontKerning Normal { get;} = new()
    {
        Value = "normal",
    };
    /// <summary>
    /// Font kerning information stored in the font is disabled.
    /// </summary>
    public static FontKerning None { get;} = new()
    {
        Value = "none",
    };
}

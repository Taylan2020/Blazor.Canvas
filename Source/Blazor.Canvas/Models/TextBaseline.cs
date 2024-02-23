namespace Blazor.Canvas.Models;
/// <summary>
/// The CanvasRenderingContext2D.textBaseline property of the Canvas 2D API specifies the current text baseline used when drawing text.
/// </summary>
public record TextBaseline
{
    internal string? Value { get; init; }
    /// <summary>
    /// The text baseline is the top of the em square.
    /// </summary>
    public readonly static TextBaseline Top = new()
    {
        Value = "top",
    };
    /// <summary>
    /// The text baseline is the hanging baseline. (Used by Tibetan and other Indic scripts.)
    /// </summary>
    public readonly static TextBaseline Hanging = new()
    {
        Value = "hanging",
    };
    /// <summary>
    /// The text baseline is the middle of the em square.
    /// </summary>
    public readonly static TextBaseline Middle = new()
    {
        Value = "middle",
    };
    /// <summary>
    /// The text baseline is the normal alphabetic baseline. Default value.
    /// </summary>
    public readonly static TextBaseline Alphabet = new()
    {
        Value = "alphabet",
    };
    /// <summary>
    /// The text baseline is the ideographic baseline; this is the bottom of the body of the characters, if the main body of characters protrudes beneath the alphabetic baseline. (Used by Chinese, Japanese, and Korean scripts.)
    /// </summary>
    public readonly static TextBaseline Ideographic = new()
    {
        Value = "ideographic",
    };
    /// <summary>
    /// The text baseline is the bottom of the bounding box. This differs from the ideographic baseline in that the ideographic baseline doesn't consider descenders.
    /// </summary>
    public readonly static TextBaseline Bottom = new()
    {
        Value = "bottom",
    };
}

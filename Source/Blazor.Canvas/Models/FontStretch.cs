namespace Blazor.Canvas.Models;
/// <summary>
/// The CanvasRenderingContext2D.fontStretch property of the Canvas API specifies how the font may be expanded or condensed when drawing text. The property corresponds to the font-stretch CSS property when used with keywords(percentage values are not supported).
/// </summary>
public record FontStretch
{
    internal FontStretch() { }
    internal string? Value { get; init; }
    /// <summary>
    /// Specifies the most condensed font face
    /// </summary>
    public static FontStretch UltraCondensed {get;} = new()
    {
        Value = "ultra-condensed",
    };
    /// <summary>
    /// Specifies a high condensed font face
    /// </summary>
    public static FontStretch ExtraCondensed { get;} = new()
    {
        Value = "extra-condensed",
    };
    /// <summary>
    /// Specifies a more condensed font face than normal
    /// </summary>
    public static FontStretch condensed { get;} = new()
    {
        Value = "condensed",
    };
    /// <summary>
    /// Specifies a semi condensed font face
    /// </summary>
    public static FontStretch SemiCondensed { get;} = new()
    {
        Value = "semi-condensed",
    };
    /// <summary>
    /// Specifies a normal font face.
    /// </summary>
    public static FontStretch Normal { get;} = new()
    {
        Value = "normal ",
    };
    /// <summary>
    /// Specifies an expanded font face.
    /// </summary>
    public static FontStretch SemiExpanded { get;} = new()
    {
        Value = "semi-expanded",
    };
    /// <summary>
    /// Specifies a more expanded font face than normal.
    /// </summary>
    public static FontStretch Expanded { get;} = new()
    {
        Value = "expanded",
    };
    /// <summary>
    /// Specifies a high expanded font face.
    /// </summary>
    public static FontStretch ExtraExpanded { get;} = new()
    {
        Value = "extra-expanded",
    };
    /// <summary>
    /// Specifies the most expanded font face.
    /// </summary>
    public static FontStretch UltraExpanded { get;} = new()
    {
        Value = "ultra-expanded",
    };
}

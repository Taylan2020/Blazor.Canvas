namespace Blazor.Canvas.Models;
/// <summary>
/// The CanvasRenderingContext2D.textRendering property of the Canvas API provides information to the rendering engine about what to optimize for when rendering text.
/// The values correspond to the SVG text-rendering attribute(and CSS text-rendering property).
/// </summary>
public record TextRendering
{
    internal TextRendering() { }
    internal string? Value { get; init; }
    /// <summary>
    /// The browser makes educated guesses about when to optimize for speed, legibility, and geometric precision while drawing text.
    /// </summary>
    public static TextRendering Auto {get;} = new()
    {
        Value = "auto",
    };
    /// <summary>
    /// The browser emphasizes rendering speed over legibility and geometric precision when drawing text. It disables kerning and ligatures.
    /// </summary>
    public static TextRendering OptimizeSpeed {get;} = new()
    {
        Value = "optimizeSpeed",
    };
    /// <summary>
    /// The browser emphasizes legibility over rendering speed and geometric precision. This enables kerning and optional ligatures.
    /// </summary>
    public static TextRendering OptimizeLegibility {get;} = new()
    {
        Value = "optimizeLegibility",
    };
    /// <summary>
    /// The browser emphasizes geometric precision over rendering speed and legibility. Certain aspects of fonts — such as kerning — don't scale linearly. For large scale factors, you might see less-than-beautiful text rendering, but the size is what you would expect (neither rounded up nor down to the nearest font size supported by the underlying operating system).
    /// </summary>
    public static TextRendering GeometricPrecision {get;} = new()
    {
        Value = "geometricPrecision",
    };
}

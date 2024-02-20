namespace Blazor.Canvas.Models;
/// <summary>
/// The CanvasRenderingContext2D.lineJoin property of the Canvas 2D API determines the shape used to join two line segments where they meet. This property has no effect wherever two connected segments have the same direction, because no joining area will be added in this case. Degenerate segments with a length of zero (i.e., with all endpoints and control points at the exact same position) are also ignored.
/// </summary>
public record LineJoin
{
    internal LineJoin() { }
    internal string? Value { get; init; }
    /// <summary>
    /// Fills an additional triangular area between the common endpoint of connected segments, and the separate outside rectangular corners of each segment.
    /// </summary>
    public static LineJoin Bevel {get;} = new()
    {
        Value = "bevel",
    };
    /// <summary>
    /// Rounds off the corners of a shape by filling an additional sector of disc centered at the common endpoint of connected segments. The radius for these rounded corners is equal to the line width.
    /// </summary>
    public static LineJoin Round {get;} = new()
    {
        Value = "round",
    };
    /// <summary>
    /// Connected segments are joined by extending their outside edges to connect at a single point, with the effect of filling an additional lozenge-shaped area. This setting is affected by the miterLimit property. Default value.
    /// </summary>
    public static LineJoin Miter {get;} = new()
    {
        Value = "miter",
    };
}

namespace Blazor.Canvas.Models;
/// <summary>
/// The CanvasRenderingContext2D.lineCap property of the Canvas 2D API determines the shape used to draw the end points of lines.
/// </summary>
public record LineCap
{
    internal LineCap() { }
    internal string? Value { get; init; }
    /// <summary>
    /// The ends of lines are squared off at the endpoints. Default value.
    /// </summary>
    public static LineCap Butt {get;} = new()
    {
        Value = "butt",
    };
    /// <summary>
    /// The ends of lines are rounded.
    /// </summary>
    public static LineCap Round {get;} = new()
    {
        Value = "round",
    };
    /// <summary>
    /// The ends of lines are squared off by adding a box with an equal width and half the height of the line's thickness.
    /// </summary>
    public static LineCap Square {get;} = new()
    {
        Value = "square",
    };
}

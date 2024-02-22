namespace Blazor.Canvas.Models.DOM;

/// <summary>
/// An object specifying the location and dimensions of a rectangle
/// </summary>
public class Rectangle
{
    /// <summary>
    /// The coordinate of the left side of the rectangle.
    /// </summary>
    public double X { get; init; }
    /// <summary>
    /// The coordinate of the top side of the rectangle.
    /// </summary>
    public double Y { get; init; }
    /// <summary>
    /// The width of the rectangle.
    /// </summary>
    public double Width { get; init; }
    /// <summary>
    /// The height of the rectangle.
    /// </summary>
    public double Height { get; init; }
}

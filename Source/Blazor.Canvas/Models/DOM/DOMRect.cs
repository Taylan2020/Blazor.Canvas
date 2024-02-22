namespace Blazor.Canvas.Models.DOM;

/// <summary>
/// A DOMRect describes the size and position of a rectangle. The type of box represented by the DOMRect is specified by the method or property that returned it.
/// </summary>
public class DOMRect
{
    /// <summary>
    /// The x coordinate of the DOMRect's origin (typically the top-left corner of the rectangle).
    /// </summary>
    public double X { get; init; }
    /// <summary>
    /// The y coordinate of the DOMRect's origin (typically the top-left corner of the rectangle).
    /// </summary>
    public double Y { get; init; }
    /// <summary>
    /// The width of the DOMRect.
    /// </summary>
    public double Width { get; init; }
    /// <summary>
    /// The height of the DOMRect.
    /// </summary>
    public double Height { get; init; }
    /// <summary>
    /// Returns the top coordinate value of the DOMRect (has the same value as y, or y + height if height is negative).
    /// </summary>
    public double Top { get; init; }
    /// <summary>
    /// Returns the right coordinate value of the DOMRect (has the same value as x + width, or x if width is negative).
    /// </summary>
    public double Right { get; init; }
    /// <summary>
    /// Returns the bottom coordinate value of the DOMRect (has the same value as y + height, or y if height is negative).
    /// </summary>
    public double Bottom { get; init; }
    /// <summary>
    /// Returns the left coordinate value of the DOMRect (has the same value as x, or x + width if width is negative).
    /// </summary>
    public double Left { get; init; }

    /// <summary>
    /// Creates a new DOMRect object.
    /// </summary>
    public DOMRect(){}
    /// <summary>
    /// Creates a new DOMRect object with a given location and dimensions.
    /// </summary>
    /// <param name="rectangle">An object specifying the location and dimensions of a rectangle</param>
    /// <returns></returns>
    public static DOMRect FromRect(Rectangle rectangle)
    {
        return new()
        {
            Width = rectangle.Width,
            Height = rectangle.Height,
            X = rectangle.X,
            Y = rectangle.Y
        };
    }
}

namespace Blazor.Canvas.Models.Gradient;

/// <summary>
/// a gradient around a point with given coordinates.
/// </summary>
public class ConicGradient : CanvasGradient
{
    /// <summary>
    /// The angle at which to begin the gradient, in radians. The angle starts from a line going horizontally right from the center, and proceeds clockwise.
    /// </summary>
    public int StartAngle { get; private set; }
    /// <summary>
    /// The x-axis coordinate of the center of the gradient.
    /// </summary>
    public int X { get; private set; }
    /// <summary>
    /// The y-axis coordinate of the center of the gradient.
    /// </summary>
    public int Y { get; private set; }
    /// <summary>
    /// Creates a gradient around a point with given coordinates.
    /// </summary>
    /// <param name="startAngle">The x-axis coordinate of the start circle.</param>
    /// <param name="x">The y-axis coordinate of the start circle.</param>
    /// <param name="y">The radius of the start circle. Must be non-negative and finite.</param>
    /// <param name="colorStops">Color stops to be added to a given canvas gradient.</param>
    public ConicGradient(int startAngle, int x, int y, List<ColorStop> colorStops):base(colorStops) {
        StartAngle = startAngle;
        X = x;
        Y = y;
    }
}

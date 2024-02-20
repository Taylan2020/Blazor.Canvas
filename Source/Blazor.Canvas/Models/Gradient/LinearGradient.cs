namespace Blazor.Canvas.Models.Gradient;

/// <summary>
/// A gradient along the line connecting two given coordinates.
/// </summary>
public class LinearGradient:CanvasGradient
{
    /// <summary>
    /// The x-axis coordinate of the start point.
    /// </summary>
    public int X0 { get; private set; }
    /// <summary>
    /// The y-axis coordinate of the start point.
    /// </summary>
    public int Y0 { get; private set; }
    /// <summary>
    /// The x-axis coordinate of the end point.
    /// </summary>
    public int X1 { get; private set; }
    /// <summary>
    /// The y-axis coordinate of the end point.
    /// </summary>
    public int Y1 { get; private set; }
    /// <summary>
    /// Creates a gradient along the line connecting two given coordinates.
    /// </summary>
    /// <param name="x0">The x-axis coordinate of the start point.</param>
    /// <param name="y0">The y-axis coordinate of the start point.</param>
    /// <param name="x1">The x-axis coordinate of the end point.</param>
    /// <param name="y1">The y-axis coordinate of the end point.</param>
    /// <param name="colorStops">Color stops to be added to a given canvas gradient.</param>
    public LinearGradient(int x0, int y0, int x1, int y1, List<ColorStop> colorStops):base(colorStops)
    {
        X0 = x0;
        X1 = x1;
        Y0 = y0;
        Y1 = y1;
    }
}

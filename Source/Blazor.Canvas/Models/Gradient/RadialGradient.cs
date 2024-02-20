namespace Blazor.Canvas.Models.Gradient;

/// <summary>
/// A gradient along the line connecting two given coordinates.
/// </summary>
public class RadialGradient : CanvasGradient
{
    /// <summary>
    /// The x-axis coordinate of the start circle.
    /// </summary>
    public int X0 { get; private set; }
    /// <summary>
    /// The y-axis coordinate of the start circle.
    /// </summary>
    public int Y0 { get; private set; }
    /// <summary>
    /// The radius of the start circle. Must be non-negative and finite.
    /// </summary>
    public int R0 { get; private set; }
    /// <summary>
    /// The x-axis coordinate of the end circle.
    /// </summary>
    public int X1 { get; private set; }
    /// <summary>
    /// The y-axis coordinate of the end circle.
    /// </summary>
    public int Y1 { get; private set; }
    /// <summary>
    /// The radius of the end circle. Must be non-negative and finite.
    /// </summary>
    public int R1 { get; private set; }
    /// <summary>
    /// Creates a gradient along the line connecting two given coordinates.
    /// </summary>
    /// <param name="x0">The x-axis coordinate of the start circle.</param>
    /// <param name="y0">The y-axis coordinate of the start circle.</param>
    /// <param name="r0">The radius of the start circle. Must be non-negative and finite.</param>
     /// <param name="x1">The x-axis coordinate of the end circle.</param>
    /// <param name="y1">The y-axis coordinate of the end circle.</param>
    /// <param name="r1">The radius of the start circle. Must be non-negative and finite.</param>
   /// <param name="colorStops">Color stops to be added to a given canvas gradient.</param>
    public RadialGradient(int x0, int y0, int r0, int x1, int y1, int r1, List<ColorStop> colorStops):base(colorStops)
    {
        X0 = x0;
        Y0 = y0;
        R0 = r0;
        X1 = x1;
        Y1 = y1;
        R1 = r1;
    }
}

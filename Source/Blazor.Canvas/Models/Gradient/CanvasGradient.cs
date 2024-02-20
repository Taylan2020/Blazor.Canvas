namespace Blazor.Canvas.Models.Gradient;
/// <summary>
/// The CanvasGradient interface represents an opaque object describing a gradient.
/// </summary>
public class CanvasGradient
{
    /// <param name="colorStops">Color stops to be added to a given canvas gradient.</param>
    public CanvasGradient(List<ColorStop> colorStops) { ColorStops = colorStops; }
    internal List<ColorStop> ColorStops { get; init; } = new();
}

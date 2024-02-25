namespace Blazor.Canvas.Models.DOM;

/// <summary>
/// Provides current values of the canvas/canvas container elements and window-object properties: boundingRect-..., client-..., offset-..., and Scroll...
/// </summary>
public class ViewInformation
{
    /// <inheritdoc cref="ViewInformation"/>
    public ViewInformation() { }
    /// <summary>
    /// Returns canvas element information
    /// </summary>
    public ElementInformation? Canvas { get; init; }
    /// <summary>
    /// Returns canvas container element information
    /// </summary>
    public ElementInformation? CanvasContainer { get; init; }
    /// <summary>
    /// Returns window object information
    /// </summary>
    public Window? Window { get; init; }
}

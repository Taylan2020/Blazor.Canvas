namespace Blazor.Canvas.Data;

internal struct INTEROP_NAMES
{
    internal const string CANVAS_MANAGER = "window.Blazor_Canvas_Manager";
    internal const string CANVAS_Element = $"{CANVAS_MANAGER}.Canvas";
    internal const string CANVAS_CONTAINER_ELEMENT = $"{CANVAS_MANAGER}.CanvasContainer";
    internal const string CANVAS_CONTEXT2D = $"{CANVAS_MANAGER}.CanvasContext";
}

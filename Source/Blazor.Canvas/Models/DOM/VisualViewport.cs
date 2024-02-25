using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Canvas.Models.DOM;
/// <summary>
/// The VisualViewport interface of the Visual Viewport API represents the visual viewport for a given window. For a page containing iframes, each iframe, as well as the containing page, will have a unique window object. Each window on a page will have a unique VisualViewport representing the properties associated with that window.
/// </summary>
public class VisualViewport
{
    public VisualViewport() { }
    /// <summary>
    /// The offsetLeft read-only property of the VisualViewport interface returns the offset of the left edge of the visual viewport from the left edge of the layout viewport in CSS pixels, or 0 if current document is not fully active.
    /// </summary>
    public double? OffsetLeft { get; init; } = null;
    /// <summary>
    /// The offsetTop read-only property of the VisualViewport interface returns the offset of the top edge of the visual viewport from the top edge of the layout viewport in CSS pixels, or 0 if current document is not fully active.
    /// </summary>
    public double? OffsetTop { get; init; } = null;
    /// <summary>
    /// The pageLeft read-only property of the VisualViewport interface returns the x coordinate of the left edge of the visual viewport relative to the initial containing block origin, in CSS pixels, or 0 if current document is not fully active.
    /// </summary>
    public double? PageLeft { get; init; } = null;
    /// <summary>
    /// The pageTop read-only property of the VisualViewport interface returns the y coordinate of the top edge of the visual viewport relative to the initial containing block origin, in CSS pixels, or 0 if current document is not fully active.
    /// </summary>
    public double? PageTop{ get; init; } = null;
    /// <summary>
    /// The width read-only property of the VisualViewport interface returns the width of the visual viewport, in CSS pixels, or 0 if current document is not fully active.
    /// </summary>
    public double? Width{ get; init; } = null;
    /// <summary>
    /// The height read-only property of the VisualViewport interface returns the height of the visual viewport, in CSS pixels, or 0 if current document is not fully active.
    /// </summary>
    public double? Height{ get; init; } = null;
    /// <summary>
    /// The scale read-only property of the VisualViewport interface returns the pinch-zoom scaling factor applied to the visual viewport, or 0 if current document is not fully active, or 1 if there is no output device.
    /// </summary>
    public double? Scale{ get; init; } = null;
}

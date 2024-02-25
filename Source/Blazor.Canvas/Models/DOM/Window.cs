namespace Blazor.Canvas.Models.DOM;

/// <summary>
///  Represents the window properties in which the script is running
/// </summary>
public class Window
{
    /// <inheritdoc cref="Window"/>
    public Window() { }
    /// <summary>
    /// The Window.closed read-only property indicates whether the referenced window is closed or not.
    /// </summary>
    public bool? Closed { get; init; } = null;
    /// <summary>
    /// The devicePixelRatio of Window interface returns the ratio of the resolution in physical pixels to the resolution in CSS pixels for the current display device. This value could also be interpreted as the ratio of pixel sizes: the size of one CSS pixel to the size of one physical pixel.In simpler terms, this tells the browser how many of the screen's actual pixels should be used to draw a single CSS pixel. This is useful when dealing with the difference between rendering on a standard display versus a HiDPI or Retina display, which use more screen pixels to draw the same objects, resulting in a sharper image.
    /// </summary>
    public double? DevicePixelRatio { get; init; } = null;
    /// <summary>
    /// The read-only Window property innerWidth returns the interior width of the window in pixels (that is, the width of the window's layout viewport). That includes the width of the vertical scroll bar, if one is present. Similarly, the interior height of the window(that is, the height of the layout viewport) can be obtained using the innerHeight property.That measurement also accounts for the height of the horizontal scroll bar, if it is visible.
    /// </summary>
    public int? InnerWidth { get; init; } = null;
    /// <summary>
    /// The read-only innerHeight property of the Window interface returns the interior height of the window in pixels, including the height of the horizontal scroll bar, if present. The value of innerHeight is taken from the height of the window's layout viewport. The width can be obtained using the innerWidth property.
    /// </summary>
    public int? InnerHeight { get; init; } = null;
    /// <summary>
    /// Returns the number of frames (either <frame> or <iframe> elements) in the window.
    /// </summary>
    public int? Length { get; init; } = null;
    /// <summary>
    ///  Returns the locationbar object.
    /// </summary>
    public Location? Location { get; init; } = null;
    /// <summary>
    ///  Returns the locationbar object.
    /// </summary>
    public BarPop? LocationBar { get; init; } = null;
    /// <summary>
    ///  Returns the statusbar object.
    /// </summary>
    public BarPop? Menubar { get; init; } = null;
    /// <summary>
    /// The Window.name property gets the name of the window's browsing context.
    /// </summary>
    public string? Name { get; init; } = null;
    /// <summary>
    /// Window.outerWidth read-only property returns the width of the outside of the browser window. It represents the width of the whole browser window including sidebar (if expanded), window chrome and window resizing borders/handles.
    /// </summary>
    public int? OuterWidth { get; init; } = null;
    /// <summary>
    /// The Window.outerHeight read-only property returns the height in pixels of the whole browser window, including any sidebar, window chrome, and window-resizing borders/handles.
    /// </summary>
    public int? OuterHeight { get; init; } = null;
    /// <summary>
    ///  Returns the personalbar object.
    /// </summary>
    public BarPop? PersonalBar { get; init; } = null;
    /// <summary>
    /// The Window.screenLeft read-only property returns the horizontal distance, in CSS pixels, from the left border of the user's browser viewport to the left side of the screen.
    /// </summary>
    /// <remarks>screenLeft is an alias of the older Window.screenX property. screenLeft was originally supported only in IE but was introduced everywhere due to popularity.</remarks>
    public int? ScreenLeft { get; init; } = null;
    /// <summary>
    /// The Window.screenTop read-only property returns the vertical distance, in CSS pixels, from the top border of the user's browser viewport to the top side of the screen.
    /// </summary>
    /// <remarks>screenTop is an alias of the older Window.screenY property. screenTop was originally supported only in IE but was introduced everywhere due to popularity.</remarks>
    public int? ScreenTop { get; init; } = null;
    /// <summary>
    /// The Window.screenX read-only property returns the horizontal distance, in CSS pixels, of the left border of the user's browser viewport to the left side of the screen.
    /// </summary>
    [Obsolete("An alias of screenX was implemented across modern browsers in more recent times — Window.screenLeft. This was originally supported only in IE but was introduced everywhere due to popularity.")]
    public int? ScreenX { get; init; } = null;
    /// <summary>
    /// The Window.screenY read-only property returns the vertical distance, in CSS pixels, of the top border of the user's browser viewport to the top edge of the screen.
    /// </summary>
    [Obsolete($"{nameof(ScreenY)} = null; is obsolete, use {nameof(ScreenLeft)} = null; instead.An alias of screenY was implemented across modern browsers in more recent times — Window.screenTop. This was originally supported only in IE but was introduced everywhere due to popularity.")]
    public int? ScreenY { get; init; } = null;
    /// <summary>
    /// The read-only scrollX property of the Window interface returns the number of pixels that the document is currently scrolled horizontally. This value is subpixel precise in modern browsers, meaning that it isn't necessarily a whole number. You can get the number of pixels the document is scrolled vertically from the scrollY property.
    /// </summary>
    public double? ScrollX { get; init; } = null;
    /// <summary>
    /// The read-only scrollY property of the Window interface returns the number of pixels that the document is currently scrolled vertically. This value is subpixel precise in modern browsers, meaning that it isn't necessarily a whole number. You can get the number of pixels the document is scrolled horizontally from the scrollX property.
    /// </summary>
    public double? ScrollY { get; init; } = null;
    /// <summary>
    ///  Returns the menubar object.
    /// </summary>
    public BarPop? StatusBar { get; init; } = null;
    /// <summary>
    ///  Returns the scrollbars object.
    /// </summary>
    public BarPop? ScrollBars { get; init; } = null;
    /// <summary>
    ///  Returns the toolnbar object.
    /// </summary>
    public BarPop? ToolBar { get; init; } = null;
    /// <summary>
    /// The visualViewport read-only property of the Window interface returns a VisualViewport object representing the visual viewport for a given window, or null if current document is not fully active.
    /// </summary>
    public VisualViewport? VisualViewport { get; init; } = null;
}

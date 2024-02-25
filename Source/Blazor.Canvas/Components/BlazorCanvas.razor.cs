using Blazor.Canvas.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection.Metadata;
using Image = System.Drawing.Image;
using Blazor.Canvas.Models.Filter;
using LineCap = Blazor.Canvas.Models.LineCap;
using LineJoin = Blazor.Canvas.Models.LineJoin;
using Blazor.Canvas.Models.Gradient;
using Microsoft.AspNetCore.Components.Web;
using Blazor.Canvas.Data;
using Blazor.Canvas.Models.DOM;

namespace Blazor.Canvas.Components;

/// <summary>
/// Blazor wrapper for HTML Canvas Graphics
/// </summary>
public partial class BlazorCanvas
{
    #region Properties / Fields
    #region Injects
    /// <summary>
    /// Represents an instance of a JavaScript runtime to which calls may be dispatched.
    /// </summary>
    internal IJSRuntime? _JS { get; set; }
    /// <summary>
    /// Wraps a JS interop argument, indicating that the value should not be serialized as JSON
    /// but instead should be passed as a reference.
    /// </summary>
    internal DotNetObjectReference<BlazorCanvas>? _DotNetRef;
    #endregion

    #region Parameters
    /// <summary>
    /// Defines an identifier (ID) for the canvas element which must be unique in the whole document.
    /// </summary>
    [Parameter] public string? Id { get; set; }
    /// <summary>
    /// Defines a name for the canvas element.
    /// </summary>
    [Parameter] public string? Name { get; set; }
    /// <summary>
    /// Specifies the initial starting width of the canvas element, in pixels.
    /// </summary>
    [Parameter] public int InitialWidth { get; init; }
    /// <summary>
    /// Specifies the initial starting height of the canvas element, in pixels.
    /// </summary>
    [Parameter] public int InitialHeight { get; init; }
    /// <summary>
    /// Assigns a unique style to the canvas
    /// </summary>
    [Parameter] public string? Style { get; set; }
    /// <summary>
    /// A string variable representing the class or space-separated classes of the canvas element.
    /// </summary>
    [Parameter] public string? Class { get; set; }
    /// <summary>
    /// Specifies the keyboard tab order of the input control relative to the other controls on the page.
    /// </summary>
    [Parameter] public int TabIndex { get; set; }
    /// <summary>
    /// A hidden attribute on a canvas tag hides the canvas. Although the canvas is not visible, its position on the page is maintained.
    /// </summary>
    [Parameter] public bool Hidden { get; set; }
    #endregion

    #region Fields
    /// <summary>
    /// Provides a mechanism for releasing unmanaged resources asynchronously.
    /// </summary>
    /// <summary>
    /// Current width of the canvas element, in pixels.
    /// </summary>
    public int Width { get; internal set; }
    /// <summary>
    /// Currrent height of the canvas element, in pixels.
    /// </summary>
    public int Height { get; internal set; }
    #endregion

    #region Event Callbacks
    /// <summary>
    /// The auxclick event is fired at an Element when a non-primary pointing device button (any mouse button other than the primary—usually leftmost—button) has been pressed and released both within the same element. Auxclick is fired after the mousedown and mouseup events have been fired, in that order.
    /// </summary>
    [Parameter] public EventCallback<PointerEventArgs> OnAuxClick { get; set; }
    /// <summary>
    /// An element receives a click event when any of the following occurs:
    /// <br/><br/>a pointing-device button(such as a mouse's primary button) is both pressed and released while the pointer is located inside the element.
    /// <br/><br/>a touch gesture is performed on the element
    /// <br/><br/>the Space key or Enter key is pressed while the element is focused
    /// <br/><br/>If the button is pressed on one element and the pointer is moved outside the element before the button is released, the event is fired on the most specific ancestor element that contained both elements.
    /// click fires after both the mousedown and mouseup events have fired, in that order.
    /// The event is a device-independent event — meaning it can be activated by touch, keyboard, mouse, and any other mechanism provided by assistive technology.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
    /// <summary>
    /// The contextmenu event fires when the user attempts to open a context menu. This event is typically triggered by clicking the right mouse button, or by pressing the context menu key. In the latter case, the context menu is displayed at the bottom left of the focused element, unless the element is a tree, in which case the context menu is displayed at the bottom left of the current row. Any right-click event that is not disabled (by calling the click event's preventDefault() method) will result in a contextmenu event being fired at the targeted element.
    /// </summary>
    /// <remarks>An exception to this in Firefox: if the user holds down the Shift key while right-clicking, then the context menu will be shown without a contextmenu event being fired.</remarks>
    [Parameter] public EventCallback<MouseEventArgs> OnContextMenu { get; set; }
    /// <summary>
    /// The dblclick event fires when a pointing device button (such as a mouse's primary button) is double-clicked; that is, when it's rapidly clicked twice on a single element within a very short span of time. dblclick fires after two click events(and by extension, after two pairs of mousedown and mouseup events).
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnDoubleClick { get; set; }
    /// <summary>
    /// The keyup event is fired when a key is released. The keydown and keyup events provide a code indicating which key is pressed, while keypress indicates which character was entered.For example, a lowercase "a" will be reported as 65 by keydown and keyup, but as 97 by keypress. An uppercase "A" is reported as 65 by all events. Keyboard events are only generated by input, textarea, summary and anything with the contentEditable or tabindex attribute.
    /// </summary>
    [Parameter] public EventCallback<KeyboardEventArgs> OnKeyUp { get; set; }
    /// <summary>
    /// The keydown event is fired when a key is pressed. Unlike the deprecated keypress event, the keydown event is fired for all keys, regardless of whether they produce a character value.The keydown and keyup events provide a code indicating which key is pressed, while keypress indicates which character was entered. For example, a lowercase "a" will be reported as 65 by keydown and keyup, but as 97 by keypress. An uppercase "A" is reported as 65 by all events. Keyboard events are only generated by input, textarea, summary and anything with the contentEditable or tabindex attribute. If not caught, they bubble up the DOM tree until they reach Document.
    /// </summary>
    [Parameter] public EventCallback<KeyboardEventArgs> OnKeyDown { get; set; }
    /// <summary>
    /// The keypress event is fired when a key that produces a character value is pressed down. Examples of keys that produce a character value are alphabetic, numeric, and punctuation keys.Examples of keys that don't produce a character value are modifier keys such as Alt, Shift, Ctrl, or Meta.
    /// </summary>
    [Obsolete("OnKeyPress is no longer recommended, use OnKeyDown instead. Though some browsers might still support it, it may have already been removed from the relevant web standards, may be in the process of being dropped, or may only be kept for compatibility purposes. Avoid using it, and update existing code if possible; see the compatibility table at the bottom of this page to guide your decision. Be aware that this feature may cease to work at any time.", false)]
    [Parameter] public EventCallback<KeyboardEventArgs> OnKeyPress { get; set; }
    /// <summary>
    /// The mouseover event is fired at an Element when a pointing device (such as a mouse or trackpad) is used to move the cursor onto the element or one of its child elements.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnMouseOver { get; set; }
    /// <summary>
    /// The mouseout event is fired at an Element when a pointing device (usually a mouse) is used to move the cursor so that it is no longer contained within the element or one of its children. mouseout is also delivered to an element if the cursor enters a child element, because the child element obscures the visible area of the element.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnMouseOut { get; set; }
    /// <summary>
    /// The mousemove event is fired at an element when a pointing device (usually a mouse) is moved while the cursor's hotspot is inside it.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnMouseMove { get; set; }
    /// <summary>
    /// The obsolete and non-standard mousewheel event is fired asynchronously at an Element to provide updates while a mouse wheel or similar device is operated. The mousewheel event was never part of any standard, and while it was implemented by several browsers, it was never implemented by Firefox.
    /// </summary>
    [Obsolete("This feature is no longer recommended, use the standard wheel event instead. Though some browsers might still support it, it may have already been removed from the relevant web standards, may be in the process of being dropped, or may only be kept for compatibility purposes. Avoid using it, and update existing code if possible; see the compatibility table at the bottom of this page to guide your decision. Be aware that this feature may cease to work at any time.", false)]
    [Parameter] public EventCallback<MouseEventArgs> OnMouseWheel { get; set; }
    /// <summary>
    /// The mousedown event is fired at an Element when a pointing device button is pressed while the pointer is inside the element.
    /// </summary>
    /// <remarks>This differs from the click event in that click is fired after a full click action occurs; that is, the mouse button is pressed and released while the pointer remains inside the same element. mousedown is fired the moment the button is initially pressed.</remarks>
    [Parameter] public EventCallback<MouseEventArgs> OnMouseDown { get; set; }
    /// <summary>
    /// The mouseup event is fired at an Element when a button on a pointing device (such as a mouse or trackpad) is released while the pointer is located inside it.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnMouseUp { get; set; }
    /// <summary>
    /// The blur event fires when an element has lost focus. The event does not bubble, but the related focusout event that follows does bubble. An element will lose focus if another element is selected. An element will also lose focus if a style that does not allow focus is applied, such as hidden, or if the element is removed from the document — in both of these cases focus moves to the body element(viewport). Note however that blur is not fired when a focused element is removed from the document. The opposite of blur is the focus event, which fires when the element has received focus. The blur event is not cancelable.
    /// </summary>
    [Parameter] public EventCallback<FocusEventArgs> OnBlur { get; set; }
    /// <summary>
    /// The focus event fires when an element has received focus. The event does not bubble, but the related focusin event that follows does bubble. The opposite of focus is the blur event, which fires when the element has lost focus. The focus event is not cancelable.
    /// </summary>
    [Parameter] public EventCallback<FocusEventArgs> OnFocus { get; set; }
    /// <summary>
    /// The focusin event fires when an element has received focus, after the focus event. The two events differ in that focusin bubbles, while focus does not. The opposite of focusin is the focusout event, which fires when the element has lost focus. The focusin event is not cancelable.
    /// </summary>
    [Parameter] public EventCallback<FocusEventArgs> OnFocusIn { get; set; }
    /// <summary>
    /// The focusout event fires when an element has lost focus, after the blur event. The two events differ in that focusout bubbles, while blur does not. The opposite of focusout is the focusin event, which fires when the element has received focus. The focusout event is not cancelable.
    /// </summary>
    [Parameter] public EventCallback<FocusEventArgs> OnFocusOut { get; set; }
    /// <summary>
    /// The scroll event fires when an element has been scrolled.
    /// </summary>
    [Parameter] public EventCallback<EventArgs> OnScroll { get; set; }
    /// <summary>
    /// The scrollend event fires when element scrolling has completed. Scrolling is considered completed when the scroll position has no more pending updates and the user has completed their gesture. Scroll position updates include smooth or instant mouse wheel scrolling, keyboard scrolling, scroll-snap events, or other APIs and gestures which cause the scroll position to update.User gestures like touch panning or trackpad scrolling aren't complete until pointers or keys have released. If the scroll position did not change, then no scrollend event fires.
    /// </summary>
    [Parameter] public EventCallback<EventArgs> OnScrollEnd { get; set; }
    /// <summary>
    /// The wheel event fires when the user rotates a wheel button on a pointing device (typically a mouse). This event replaces the non-standard deprecated mousewheel event.
    /// </summary>
    /// <remarks>Don't confuse the wheel event with the scroll event. The default action of a wheel event is implementation-specific, and doesn't necessarily dispatch a scroll event. Even when it does, the delta* values in the wheel event don't necessarily reflect the content's scrolling direction. Therefore, do not rely on the wheel event's delta* properties to get the scrolling direction. Instead, detect value changes of scrollLeft and scrollTop of the target in the scroll event.</remarks>
    [Parameter] public EventCallback<WheelEventArgs> OnWheel { get; set; }
    /// <summary>
    /// The touchstart event is fired when one or more touch points are placed on the touch surface.
    /// </summary>
    [Parameter] public EventCallback<TouchEventArgs> OnTouchStart { get; set; }
    /// <summary>
    /// The touchmove event is fired when one or more touch points are moved along the touch surface.
    /// </summary>
    [Parameter] public EventCallback<TouchEventArgs> OnTouchMove { get; set; }
    /// <summary>
    /// The touchend event fires when one or more touch points are removed from the touch surface. Remember that it is possible to get a touchcancel event instead.
    /// </summary>
    [Parameter] public EventCallback<TouchEventArgs> OnTouchEnd { get; set; }
    /// <summary>
    /// The touchcancel event is fired when one or more touch points have been disrupted in an implementation-specific manner.
    /// </summary>
    [Parameter] public EventCallback<TouchEventArgs> OnTouchCancel { get; set; }
    #endregion
    #endregion

    #region Methods
    #region Base
    /// <summary>
    /// Method invoked when the component has received parameters from its parent in
    /// the render tree, and the incoming values have been assigned to properties.
    /// </summary>
    protected override void OnParametersSet()
    {
        Height = InitialHeight;
        Width = InitialWidth;

        base.OnParametersSet();
    }
    /// <summary>
    /// Cleans up Blazor.Canvas resources
    /// </summary>
    /// <returns></returns>
    public void Dispose()
    {
        if (_DotNetRef is not null)
            _DotNetRef.Dispose();
    }

    #endregion

    /// <summary>
    /// Initializes the canvas
    /// </summary>
    /// <param name="_js">Represents an instance of a JavaScript runtime to which calls may be dispatched.</param>
    /// <returns></returns>
    public async Task Initialize(IJSRuntime _js)
    {
        _DotNetRef = DotNetObjectReference.Create(this);
        _JS = _js;
        await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_MANAGER}.Initialize", Id, _DotNetRef);
        await ChangeCanvasSize(InitialWidth, InitialHeight);
    }

    #region CanvasElement
    /// <summary>
    /// Each time the height or width of a canvas is re-set, the canvas content will be cleared.
    /// </summary>
    /// <param name="height">reflecting the height HTML attribute of the canvas element interpreted in CSS pixels. When the attribute is not specified, or if it is set to an invalid value, like a negative, the default value of 150 is used.</param>
    /// <param name="width">reflecting the width HTML attribute of the canvas element interpreted in CSS pixels. When the attribute is not specified, or if it is set to an invalid value, like a negative, the default value of 150 is used.</param>
    /// <returns></returns>
    public async Task ChangeCanvasSize(int height, int width)
    {
        var newSize = await _JS.InvokeAsync<int[]>($"{INTEROP_NAMES.CANVAS_MANAGER}.{nameof(ChangeCanvasSize)}", width, height);

        this.Width = newSize[0];
        this.Height = newSize[1];
    }
    /// <summary>
    /// Each time the height of a canvas is re-set, the canvas content will be cleared.
    /// </summary>
    /// <param name="height">reflecting the height HTML attribute of the canvas element interpreted in CSS pixels. When the attribute is not specified, or if it is set to an invalid value, like a negative, the default value of 0 is used.</param>
    /// <returns></returns>
    public async Task ChangeCanvasHeight(int height)
    => await SetProperty($"{INTEROP_NAMES.CANVAS_Element}.{nameof(height)}", height);
    /// <summary>
    /// Each time the width of a canvas is re-set, the canvas content will be cleared.
    /// </summary>
    /// <param name="width">reflecting the height HTML attribute of the canvas element interpreted in CSS pixels. When the attribute is not specified, or if it is set to an invalid value, like a negative, the default value of 0 is used.</param>
    /// <returns></returns>
    public async Task ChangeCanvasWidth(int width)
    => await SetProperty($"{INTEROP_NAMES.CANVAS_Element}.{nameof(width)}", width);
    /// <summary>
    /// The HTMLCanvasElement.toDataURL() method returns a data URL containing a representation of the image in the format specified by the type parameter. The desired file format and image quality may be specified. If the file format is not specified, or if the given format is not supported, then the data will be exported as image/png. In other words, if the returned value starts with data:image/png for any other requested type, then that format is not supported. Browsers are required to support image/png; many will support additional formats including image/jpeg and image/webp. The created image data will have a resolution of 96dpi for file formats that support encoding resolution metadata.
    /// </summary>
    /// <returns>A string containing the requested data URL. If the height or width of the canvas is 0 or larger than the maximum canvas size, the string "data:," is returned.</returns>
    public async Task<string> ToDataURL()
        => await _JS.InvokeAsync<string>($"{INTEROP_NAMES.CANVAS_Element}.{nameof(ToDataURL).ToCamelCase()}");
    /// <summary>
    /// The HTMLCanvasElement.toDataURL() method returns a data URL containing a representation of the image in the format specified by the type parameter. The desired file format and image quality may be specified. If the file format is not specified, or if the given format is not supported, then the data will be exported as image/png. In other words, if the returned value starts with data:image/png for any other requested type, then that format is not supported. Browsers are required to support image/png; many will support additional formats including image/jpeg and image/webp. The created image data will have a resolution of 96dpi for file formats that support encoding resolution metadata.
    /// </summary>
    /// <param name="type">A string indicating the image format. The default type is image/png; this image format will be also used if the specified type is not supported.</param>
    /// <returns>A string containing the requested data URL. If the height or width of the canvas is 0 or larger than the maximum canvas size, the string "data:," is returned.</returns>
    public async Task<string> ToDataURL(string type = "image/png")
        => await _JS.InvokeAsync<string>($"{INTEROP_NAMES.CANVAS_Element}.{nameof(ToDataURL).ToCamelCase()}", type);
    /// <summary>
    /// The HTMLCanvasElement.toDataURL() method returns a data URL containing a representation of the image in the format specified by the type parameter. The desired file format and image quality may be specified. If the file format is not specified, or if the given format is not supported, then the data will be exported as image/png. In other words, if the returned value starts with data:image/png for any other requested type, then that format is not supported. Browsers are required to support image/png; many will support additional formats including image/jpeg and image/webp. The created image data will have a resolution of 96dpi for file formats that support encoding resolution metadata.
    /// </summary>
    /// <param name="type">A string indicating the image format. The default type is image/png; this image format will be also used if the specified type is not supported.</param>
    /// <param name="encoderOptions">A Number between 0 and 1 indicating the image quality to be used when creating images using file formats that support lossy compression (such as image/jpeg or image/webp). A user agent will use its default quality value if this option is not specified, or if the number is outside the allowed range.</param>
    /// <returns>A string containing the requested data URL. If the height or width of the canvas is 0 or larger than the maximum canvas size, the string "data:," is returned.</returns>
    public async Task<string> ToDataURL(string type = "image/png", float encoderOptions = 1.0f)
    {
        if (encoderOptions < 0 || encoderOptions > 1)
            throw new ArgumentException($"The provided {nameof(encoderOptions)} value ({encoderOptions}) is outside the range (0.0, 1.0).");


        return await _JS.InvokeAsync<string>($"{INTEROP_NAMES.CANVAS_Element}.{nameof(ToDataURL).ToCamelCase()}", type, encoderOptions);
    }
    /// <summary>
    /// Returns a DOMRect object providing information about the size of the canvas and its position relative to the viewport.
    /// </summary>
    /// <returns></returns>
    public async Task<DOMRect> GetBoundingClientRect()
    => await _JS.InvokeAsync<DOMRect>($"{INTEROP_NAMES.CANVAS_MANAGER}.{nameof(GetBoundingClientRect)}");
    #endregion

    #region CanvasRenderingContext
    #region Methods
    /// <summary>
    /// The CanvasRenderingContext2D.arc() method of the Canvas 2D API adds a circular arc to the current sub-path.
    /// </summary>
    /// <param name="x">The horizontal coordinate of the arc's center.</param>
    /// <param name="y">The vertical coordinate of the arc's center.</param>
    /// <param name="radius">The arc's radius. Must be positive.</param>
    /// <param name="startAngle">The angle at which the arc starts in radians, measured from the positive x-axis.</param>
    /// <param name="endAngle">The angle at which the arc ends in radians, measured from the positive x-axis.</param>
    /// <param name="counterClockWise"></param>
    /// <returns>An optional boolean value. If true, draws the arc counter-clockwise between the start and end angles. The default is false (clockwise).</returns>
    public async Task Arc(int x, int y, decimal radius, int startAngle, int endAngle, bool counterClockWise = false)
    => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(Arc).ToCamelCase()}", x, y, radius, startAngle, endAngle, counterClockWise);
    /// <summary>
    /// The CanvasRenderingContext2D.arcTo() method of the Canvas 2D API adds a circular arc to the current sub-path, using the given control points and radius. The arc is automatically connected to the path's latest point with a straight line if necessary, for example if the starting point and control points are in a line.This method is commonly used for making rounded corners.
    /// </summary>
    /// <param name="x1">The x-axis coordinate of the first control point.</param>
    /// <param name="y1">The y-axis coordinate of the first control point.</param>
    /// <param name="x2">The x-axis coordinate of the second control point.</param>
    /// <param name="y2">The y-axis coordinate of the second control point.</param>
    /// <param name="radius">The arc's radius. Must be non-negative.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public async Task ArcTo(int x1, int y1, int x2, int y2, decimal radius)
    {
        if (radius < 0)
            throw new ArgumentException($"ArcTo does not accept a negative radius: '{radius}'!");

        await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(ArcTo).ToCamelCase()}", x1, y1, x2, y2, radius);
    }
    /// <summary>
    /// The CanvasRenderingContext2D.beginPath() method of the Canvas 2D API starts a new path by emptying the list of sub-paths. Call this method when you want to create a new path.
    /// </summary>
    /// <returns></returns>
    public async Task BeginPath()
      => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(BeginPath).ToCamelCase()}");
    /// <summary>
    /// The CanvasRenderingContext2D.bezierCurveTo() method of the Canvas 2D API adds a cubic Bézier curve to the current sub-path. It requires three points: the first two are control points and the third one is the end point. The starting point is the latest point in the current path, which can be changed using moveTo() before creating the Bézier curve.
    /// </summary>
    /// <param name="cp1x">The x-axis coordinate of the first control point.</param>
    /// <param name="cp1y">The y-axis coordinate of the first control point.</param>
    /// <param name="cp2x">The x-axis coordinate of the second control point.</param>
    /// <param name="cp2y">The y-axis coordinate of the second control point.</param>
    /// <param name="x">The x-axis coordinate of the end point.</param>
    /// <param name="y">The y-axis coordinate of the end point.</param>
    /// <returns></returns>
    public async Task BezierCurveTo(int cp1x, int cp1y, int cp2x, int cp2y, int x, int y)
      => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(BezierCurveTo).ToCamelCase()}", cp1x, cp1y, cp2x, cp2y, x, y);
    /// <summary>
    /// The CanvasRenderingContext2D.clearRect() method of the Canvas 2D API erases the pixels in a rectangular area by setting them to transparent black.
    /// </summary>
    /// <param name="x">The x-axis coordinate of the rectangle's starting point.</param>
    /// <param name="y">The y-axis coordinate of the rectangle's starting point.</param>
    /// <param name="width">The rectangle's width. Positive values are to the right, and negative to the left.</param>
    /// <param name="height">The rectangle's height. Positive values are down, and negative are up.</param>
    /// <returns></returns>
    public async Task ClearRect(int x, int y, int width, int height)
    => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(ClearRect).ToCamelCase()}", x, y, width, height);
    /// <summary>
    /// The CanvasRenderingContext2D.clip() method of the Canvas 2D API turns the current or given path into the current clipping region. The previous clipping region, if any, is intersected with the current or given path to create the new clipping region.In the image below, the red outline represents a clipping region shaped like a star.Only those parts of the checkerboard pattern that are within the clipping region get drawn.
    /// </summary>
    /// <returns></returns>
    public async Task Clip()
    => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(Clip).ToCamelCase()}");

    internal void Clip(int[] path)
    {
        throw new NotImplementedException();
    }
    internal void Clip(object fillRule)
    {
        throw new NotImplementedException();
    }
    internal void Clip(object path, object fillRule)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// The CanvasRenderingContext2D.closePath() method of the Canvas 2D API attempts to add a straight line from the current point to the start of the current sub-path. If the shape has already been closed or has only one point, this function does nothing.This method doesn't draw anything to the canvas directly. You can render the path using the stroke() or fill() methods.
    /// </summary>
    /// <returns></returns>
    public async Task ClosePath()
        => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(ClosePath).ToCamelCase()}");
    /// <summary>
    /// The CanvasRenderingContext2D.createConicGradient() method of the Canvas 2D API creates a gradient around a point with given coordinates.This method returns a conic CanvasGradient.To be applied to a shape, the gradient must first be assigned to the fillStyle or strokeStyle properties.
    /// </summary>
    /// <param name="startAngle">The angle at which to begin the gradient, in radians. The angle starts from a line going horizontally right from the center, and proceeds clockwise.</param>
    /// <param name="x">The x-axis coordinate of the center of the gradient.</param>
    /// <param name="y">The y-axis coordinate of the center of the gradient.</param>
    /// <returns>A conic CanvasGradient.</returns>
    public async Task CreateConicGradient(int startAngle, int x, int y)
      => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(CreateConicGradient).ToCamelCase()}", startAngle, x, y);
    /// <summary>
    /// The CanvasRenderingContext2D.createImageData() method of the Canvas 2D API creates a new, blank ImageData object with the specified dimensions. All of the pixels in the new object are transparent black.
    /// </summary>
    /// <param name="width">The width to give the new ImageData object. A negative value flips the rectangle around the vertical axis.</param>
    /// <param name="height">The height to give the new ImageData object. A negative value flips the rectangle around the horizontal axis.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    internal Image CreateImageData(int width, int height)
    {
        throw new NotImplementedException();
    }
    internal Image CreateImageData(int width, int height, object settings)
    {
        throw new NotImplementedException();
    }
    internal Image CreateImageData(Image imagedata)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// The CanvasRenderingContext2D.createLinearGradient() method of the Canvas 2D API creates a gradient along the line connecting two given coordinates.
    /// </summary>
    /// <param name="x0">The x-axis coordinate of the start point.</param>
    /// <param name="y0">The y-axis coordinate of the start point.</param>
    /// <param name="x1">The x-axis coordinate of the end point.</param>
    /// <param name="y1">The y-axis coordinate of the end point.</param>
    /// <returns></returns>
    public async Task CreateLinearGradient(int x0, int y0, int x1, int y1)
       => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(CreateConicGradient).ToCamelCase()}", x0, y0, x1, y1);
    /// <summary>
    /// The CanvasRenderingContext2D.createPattern() method of the Canvas 2D API creates a pattern using the specified image and repetition. This method returns a CanvasPattern.This method doesn't draw anything to the canvas directly. The pattern it creates must be assigned to the CanvasRenderingContext2D.fillStyle or CanvasRenderingContext2D.strokeStyle properties, after which it is applied to any subsequent drawing.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    internal void CreatePattern()
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// The CanvasRenderingContext2D.createRadialGradient() method of the Canvas 2D API creates a radial gradient using the size and coordinates of two circles.This method returns a CanvasGradient.To be applied to a shape, the gradient must first be assigned to the fillStyle or strokeStyle properties.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    internal void CreateRadialGradient()
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// The CanvasRenderingContext2D.drawFocusIfNeeded() method of the Canvas 2D API draws a focus ring around the current or given path, if the specified element is focused.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    internal void DrawFocusIfNeeded()
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// The CanvasRenderingContext2D.drawImage() method of the Canvas 2D API provides different ways to draw an image onto the canvas.
    /// </summary>
    /// <param name="staticImageUrl">The specification permits a static image url.</param>
    /// <param name="dx">The x-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
    /// <param name="dy">The y-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
    /// <returns></returns>
    public async Task DrawImage(string staticImageUrl, int dx, int dy)
    => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_MANAGER}.{nameof(DrawImage)}", staticImageUrl, dx, dy);
    /// <summary>
    /// The CanvasRenderingContext2D.drawImage() method of the Canvas 2D API provides different ways to draw an image onto the canvas.
    /// </summary>
    /// <param name="staticImageUrl">The specification permits a static image url.</param>
    /// <param name="dx">The x-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
    /// <param name="dy">The y-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
    /// <param name="dWidth">The width to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in width when drawn. Note that this argument is not included in the 3-argument syntax.</param>
    /// <param name="dHeight">The height to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in height when drawn. Note that this argument is not included in the 3-argument syntax.</param>
    /// <returns></returns>
    public async Task DrawImage(string staticImageUrl, int dx, int dy, int dWidth, int dHeight)
    => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_MANAGER}.{nameof(DrawImage)}", staticImageUrl, dx, dy, dWidth, dHeight);
    /// <summary>
    /// The CanvasRenderingContext2D.drawImage() method of the Canvas 2D API provides different ways to draw an image onto the canvas.
    /// </summary>
    /// <param name="staticImageUrl">The specification permits a static image url.</param>
    /// <param name="sx">The x-axis coordinate of the top left corner of the sub-rectangle of the source image to draw into the destination context. Use the 3- or 5-argument syntax to omit this argument.</param>
    /// <param name="sy">The y-axis coordinate of the top left corner of the sub-rectangle of the source image to draw into the destination context. Use the 3- or 5-argument syntax to omit this argument.</param>
    /// <param name="sWidth">The width of the sub-rectangle of the source image to draw into the destination context. If not specified, the entire rectangle from the coordinates specified by sx and sy to the bottom-right corner of the image is used. Use the 3- or 5-argument syntax to omit this argument. A negative value will flip the image..</param>
    /// <param name="sHeight">The height of the sub-rectangle of the source image to draw into the destination context. Use the 3- or 5-argument syntax to omit this argument. A negative value will flip the image.</param>
    /// <param name="dx">The x-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
    /// <param name="dy">The y-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
    /// <param name="dWidth">The width to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in width when drawn. Note that this argument is not included in the 3-argument syntax.</param>
    /// <param name="dHeight">The height to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in height when drawn. Note that this argument is not included in the 3-argument syntax.</param>
    /// <returns></returns>
    public async Task DrawImage(string staticImageUrl, int sx, int sy, int sWidth, int sHeight, int dx, int dy, int dWidth, int dHeight)
    => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_MANAGER}.{nameof(DrawImage)}", staticImageUrl, sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight);

    /// <summary>
    /// The CanvasRenderingContext2D.ellipse() method of the Canvas 2D API adds an elliptical arc to the current sub-path.
    /// </summary>
    /// <param name="x">The x-axis (horizontal) coordinate of the ellipse's center.</param>
    /// <param name="y">The y-axis (vertical) coordinate of the ellipse's center.</param>
    /// <param name="radiusX">The ellipse's major-axis radius. Must be non-negative.</param>
    /// <param name="radiusY">The ellipse's minor-axis radius. Must be non-negative.</param>
    /// <param name="rotation">The rotation of the ellipse, expressed in radians.</param>
    /// <param name="startAngle">The eccentric angle at which the ellipse starts, measured clockwise from the positive x-axis and expressed in radians.</param>
    /// <param name="endAngle">The eccentric angle at which the ellipse ends, measured clockwise from the positive x-axis and expressed in radians.</param>
    /// <param name="counterClockWise">An optional boolean value which, if true, draws the ellipse counterclockwise (anticlockwise). The default value is false (clockwise).</param>
    /// <returns></returns>
    public async Task Ellipse(int x, int y, int radiusX, int radiusY, int rotation, int startAngle, int endAngle, bool counterClockWise = false)
  => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(Ellipse).ToCamelCase()}", x, y, radiusX, radiusY, rotation, startAngle, endAngle, counterClockWise);
    /// <summary>
    /// The CanvasRenderingContext2D.fill() method of the Canvas 2D API fills the current or given path with the current fillStyle.
    /// </summary>
    /// <returns></returns>
    public async Task Fill()
     => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(Fill).ToCamelCase()}");
    /// <summary>
    /// The CanvasRenderingContext2D.fillRect() method of the Canvas 2D API draws a rectangle that is filled according to the current fillStyle.This method draws directly to the canvas without modifying the current path, so any subsequent fill() or stroke() calls will have no effect on it.
    /// </summary>
    /// <param name="x">The x-axis coordinate of the rectangle's starting point.</param>
    /// <param name="y">The y-axis coordinate of the rectangle's starting point.</param>
    /// <param name="width">The rectangle's width. Positive values are to the right, and negative to the left.</param>
    /// <param name="height">The rectangle's height. Positive values are down, and negative are up.</param>
    /// <returns></returns>
    public async Task FillRect(int x, int y, int width, int height)
     => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(FillRect).ToCamelCase()}", x, y, width, height);
    /// <summary>
    /// The CanvasRenderingContext2D method fillText(), part of the Canvas 2D API, draws a text string at the specified coordinates, filling the string's characters with the current fillStyle. An optional parameter allows specifying a maximum width for the rendered text, which the user agent will achieve by condensing the text or by using a lower font size.This method draws directly to the canvas without modifying the current path, so any subsequent fill() or stroke() calls will have no effect on it.The text is rendered using the font and text layout configuration as defined by the font, textAlign, textBaseline, and direction properties.
    /// </summary>
    /// <param name="text">A string specifying the text string to render into the context. The text is rendered using the settings specified by font, textAlign, textBaseline, and direction.</param>
    /// <param name="x">The x-axis coordinate of the point at which to begin drawing the text, in pixels.</param>
    /// <param name="y">The y-axis coordinate of the baseline on which to begin drawing the text, in pixels.</param>
    /// <param name="maxWidth">The maximum number of pixels wide the text may be once rendered. If not specified, there is no limit to the width of the text. However, if this value is provided, the user agent will adjust the kerning, select a more horizontally condensed font (if one is available or can be generated without loss of quality), or scale down to a smaller font size in order to fit the text in the specified width.</param>
    /// <returns></returns>
    public async Task FillText(string? text, int x, int y, int maxWidth)
        => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(FillText).ToCamelCase()}", text ?? string.Empty, x, y, maxWidth);
    ///<inheritdoc cref="FillText(string?, int, int, int)"/>
    public async Task FillText(string? text, int x, int y)
    => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(FillText).ToCamelCase()}", text ?? string.Empty, x, y);
    /// <summary>
    /// The CanvasRenderingContext2D.isContextLost() method of the Canvas 2D API returns true if the rendering context is lost (and has not yet been reset). This might occur due to driver crashes, running out of memory, and so on.If the user agent detects that the canvas backing storage is lost it will fire the contextlost event at the associated HTMLCanvasElement.If this event is not cancelled it will attempt to reset the backing storage to the default state (this is equivalent to calling CanvasRenderingContext2D.reset()). On success it will fire the contextrestored event, indicating that the context is ready to reinitialize and redraw.
    /// </summary>
    /// <returns>true if the rendering context was lost; false otherwise.</returns>
    public async Task<bool> IsContextLost()
      => await _JS.InvokeAsync<bool>($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(IsContextLost).ToCamelCase()}");
    /// <summary>
    /// The CanvasRenderingContext2D.isPointInStroke() method of the Canvas 2D API reports whether or not the specified point is inside the area contained by the stroking of a path.
    /// </summary>
    /// <param name="x">The x-axis coordinate of the point to check.</param>
    /// <param name="y">The y-axis coordinate of the point to check.</param>
    /// <returns></returns>
    public async Task<bool> IsPointInStroke(int x, int y)
      => await _JS.InvokeAsync<bool>($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(IsPointInStroke).ToCamelCase()}", x, y);
    /// <summary>
    /// The CanvasRenderingContext2D method lineTo(), part of the Canvas 2D API, adds a straight line to the current sub-path by connecting the sub-path's last point to the specified (x, y) coordinates.Like other methods that modify the current path, this method does not directly render anything.To draw the path onto a canvas, you can use the fill() or stroke() methods.
    /// </summary>
    /// <param name="x">The x-axis coordinate of the line's end point.</param>
    /// <param name="y">The y-axis coordinate of the line's end point.</param>
    /// <returns></returns>
    public async Task LineTo(int x, int y)
      => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(LineTo).ToCamelCase()}", x, y);
    /// <summary>
    /// The CanvasRenderingContext2D.measureText() method returns a TextMetrics object that contains information about the measured text (such as its width, for example).
    /// </summary>
    /// <param name="text">The text string to measure.</param>
    /// <returns></returns>
    public async Task MeasureText(string? text)
     => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(MeasureText).ToCamelCase()}", text);
    /// <summary>
    /// The CanvasRenderingContext2D.moveTo() method of the Canvas 2D API begins a new sub-path at the point specified by the given (x, y) coordinates.
    /// </summary>
    /// <param name="x">The x-axis (horizontal) coordinate of the point.</param>
    /// <param name="y">The y-axis (vertical) coordinate of the point.</param>
    /// <returns></returns>
    public async Task MoveTo(int x, int y)
     => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(MoveTo).ToCamelCase()}", x, y);
    /// <summary>
    /// The CanvasRenderingContext2D.quadraticCurveTo() method of the Canvas 2D API adds a quadratic Bézier curve to the current sub-path. It requires two points: the first one is a control point and the second one is the end point. The starting point is the latest point in the current path, which can be changed using moveTo() before creating the quadratic Bézier curve.
    /// </summary>
    /// <param name="cpx">The x-axis coordinate of the control point.</param>
    /// <param name="cpy">The y-axis coordinate of the control point.</param>
    /// <param name="x">The x-axis coordinate of the end point.</param>
    /// <param name="y">The y-axis coordinate of the end point.</param>
    /// <returns></returns>
    public async Task QuadraticCurveTo(int cpx, int cpy, int x, int y)
      => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(QuadraticCurveTo).ToCamelCase()}", cpx, cpy, x, y);
    /// <summary>
    /// The CanvasRenderingContext2D.rect() method of the Canvas 2D API adds a rectangle to the current path.Like other methods that modify the current path, this method does not directly render anything.To draw the rectangle onto a canvas, you can use the fill() or stroke() methods.
    /// </summary>
    /// <param name="x">The x-axis coordinate of the rectangle's starting point.</param>
    /// <param name="y">The y-axis coordinate of the rectangle's starting point.</param>
    /// <param name="width">The rectangle's width. Positive values are to the right, and negative to the left.</param>
    /// <param name="height">The rectangle's height. Positive values are down, and negative are up.</param>
    /// <returns></returns>
    public async Task Rect(int x, int y, int width, int height)
      => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(Rect).ToCamelCase()}", x, y, width, height);
    /// <summary>
    /// The CanvasRenderingContext2D.reset() method of the Canvas 2D API resets the rendering context to its default state, allowing it to be reused for drawing something else without having to explicitly reset all the properties.Resetting clears the backing buffer, drawing state stack, any defined paths, and styles.This includes the current transformation matrix, compositing properties, clipping region, dash list, line styles, text styles, shadows, image smoothing, filters, and so on.
    /// </summary>
    /// <returns></returns>
    public async Task Reset()
      => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(Reset).ToCamelCase()}");
    /// <summary>
    /// The CanvasRenderingContext2D.resetTransform() method of the Canvas 2D API resets the current transform to the identity matrix.
    /// </summary>
    /// <returns></returns>
    public async Task ResetTransform()
     => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(ResetTransform).ToCamelCase()}");
    /// <summary>
    /// The CanvasRenderingContext2D.restore() method of the Canvas 2D API restores the most recently saved canvas state by popping the top entry in the drawing state stack. If there is no saved state, this method does nothing.
    /// </summary>
    /// <returns></returns>
    public async Task Restore()
     => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(Restore).ToCamelCase()}");
    /// <summary>
    /// The CanvasRenderingContext2D.rotate() method of the Canvas 2D API adds a rotation to the transformation matrix.
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    public async Task Rotate(int angle)
     => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(Rotate).ToCamelCase()}", angle);
    /// <summary>
    /// The CanvasRenderingContext2D.roundRect() method of the Canvas 2D API adds a rounded rectangle to the current path.The radii of the corners can be specified in much the same way as the CSS border-radius property.Like other methods that modify the current path, this method does not directly render anything. To draw the rounded rectangle onto a canvas, you can use the fill() or stroke() methods.
    /// </summary>
    /// <param name="x">The x-axis coordinate of the rectangle's starting point, in pixels.</param>
    /// <param name="y">The y-axis coordinate of the rectangle's starting point, in pixels.</param>
    /// <param name="width">The rectangle's width. Positive values are to the right, and negative to the left.</param>
    /// <param name="height">The rectangle's height. Positive values are down, and negative are up.</param>
    /// <param name="radii">A number or list specifying the radii of the circular arc to be used for the corners of the rectangle. The number and order of the radii function in the same way as the border-radius CSS property when width and height are positive:<br/><br/>
    /// all-corners<br/>
    /// [all - corners]<br/>
    /// [top - left - and - bottom - right, top - right - and - bottom - left]<br/>
    /// [top - left, top - right - and - bottom - left, bottom - right]<br/>
    /// [top - left, top - right, bottom - right, bottom - left]<br/><br/>
    /// If width is negative the rounded rectangle is flipped horizontally, so the radius values that normally apply to the left corners are used on the right and vice versa.Similarly, when height is negative, the rounded rect is flipped vertically. The specified radii may be scaled (reduced) if any of the edges are shorter than the combined radius of the vertices on either end.
    /// The radii parameter can also be a DOMPoint or DOMPointReadOnly instance, or an object containing the same properties ({ x: 0, y: 0}), or a list of such objects, or a list mixing numbers and such objects.</param>
    /// <returns></returns>
    public async Task RoundRect(int x, int y, int width, int height, int[] radii)
     => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(RoundRect).ToCamelCase()}", x, y, width, height, radii);
    /// <summary>
    /// The CanvasRenderingContext2D.save() method of the Canvas 2D API saves the entire state of the canvas by pushing the current state onto a stack.
    /// </summary>
    /// <returns></returns>
    public async Task Save()
     => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(Save).ToCamelCase()}");
    /// <summary>
    /// The CanvasRenderingContext2D.scale() method of the Canvas 2D API adds a scaling transformation to the canvas units horizontally and/or vertically.By default, one unit on the canvas is exactly one pixel.A scaling transformation modifies this behavior.For instance, a scaling factor of 0.5 results in a unit size of 0.5 pixels; shapes are thus drawn at half the normal size.Similarly, a scaling factor of 2.0 increases the unit size so that one unit becomes two pixels; shapes are thus drawn at twice the normal size.
    /// </summary>
    /// <param name="x">Scaling factor in the horizontal direction. A negative value flips pixels across the vertical axis. A value of 1 results in no horizontal scaling.</param>
    /// <param name="y">Scaling factor in the vertical direction. A negative value flips pixels across the horizontal axis. A value of 1 results in no vertical scaling.</param>
    /// <returns></returns>
    public async Task Scale(int x, int y)
    => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(Scale).ToCamelCase()}", x, y);
    /// <summary>
    /// The CanvasRenderingContext2D.scrollPathIntoView() method of the Canvas 2D API scrolls the current or given path into view. It is similar to Element.scrollIntoView().
    /// </summary>
    /// <returns></returns>
    public async Task ScrollPathIntoView()
   => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(ScrollPathIntoView).ToCamelCase()}");
    /// <summary>
    /// The setLineDash() method of the Canvas 2D API's CanvasRenderingContext2D interface sets the line dash pattern used when stroking lines. It uses an array of values that specify alternating lengths of lines and gaps which describe the pattern.
    /// </summary>
    /// <param name="segments">An Array of numbers that specify distances to alternately draw a line and a gap (in coordinate space units). If the number of elements in the array is odd, the elements of the array get copied and concatenated. For example, [5, 15, 25] will become [5, 15, 25, 5, 15, 25]. If the array is empty, the line dash list is cleared and line strokes return to being solid.</param>
    /// <returns></returns>
    public async Task SetLineDash(int[] segments)
  => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(SetLineDash).ToCamelCase()}", segments);
    /// <summary>
    /// The CanvasRenderingContext2D.setTransform() method of the Canvas 2D API resets (overrides) the current transformation to the identity matrix, and then invokes a transformation described by the arguments of this method. This lets you scale, rotate, translate (move), and skew the context.
    /// </summary>
    /// <param name="a">The cell in the first row and first column of the matrix.</param>
    /// <param name="b">The cell in the second row and first column of the matrix.</param>
    /// <param name="c">The cell in the first row and second column of the matrix.</param>
    /// <param name="d">The cell in the second row and second column of the matrix.</param>
    /// <param name="e">The cell in the first row and third column of the matrix.</param>
    /// <param name="f">The cell in the second row and third column of the matrix.</param>
    /// <returns></returns>
    public async Task SetTransform(float a, float b, float c, float d, float e, float f)
   => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(SetTransform).ToCamelCase()}", a, b, c, d, e, f);
    /// <summary>
    /// The CanvasRenderingContext2D.stroke() method of the Canvas 2D API strokes (outlines) the current or given path with the current stroke style.Strokes are aligned to the center of a path; in other words, half of the stroke is drawn on the inner side, and half on the outer side.The stroke is drawn using the non-zero winding rule, which means that path intersections will still get filled.
    /// </summary>
    /// <returns></returns>
    public async Task Stroke()
    => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(Stroke).ToCamelCase()}");

    /// <inheritdoc cref="Stroke()"/>
    internal async Task Stroke(object path)
    {
        throw new NotImplementedException();
        await Task.CompletedTask;
    }
    /// <summary>
    /// The CanvasRenderingContext2D.strokeRect() method of the Canvas 2D API draws a rectangle that is stroked (outlined) according to the current strokeStyle and other context settings.This method draws directly to the canvas without modifying the current path, so any subsequent fill() or stroke() calls will have no effect on it.
    /// </summary>
    /// <param name="x">The x-axis coordinate of the rectangle's starting point.</param>
    /// <param name="y">The y-axis coordinate of the rectangle's starting point.</param>
    /// <param name="width">The rectangle's width. Positive values are to the right, and negative to the left.</param>
    /// <param name="height">The rectangle's width. Positive values are to the right, and negative to the left.</param>
    /// <returns></returns>
    public async Task StrokeRect(int x, int y, int width, int height)
   => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(StrokeRect).ToCamelCase()}", x, y, width, height);
    /// <summary>
    /// The CanvasRenderingContext2D method strokeText(), part of the Canvas 2D API, strokes — that is, draws the outlines of — the characters of a text string at the specified coordinates. An optional parameter allows specifying a maximum width for the rendered text, which the user agent will achieve by condensing the text or by using a lower font size.This method draws directly to the canvas without modifying the current path, so any subsequent fill() or stroke() calls will have no effect on it.
    /// </summary>
    /// <param name="text">A string specifying the text string to render into the context. The text is rendered using the settings specified by font, textAlign, textBaseline, and direction.</param>
    /// <param name="x">The x-axis coordinate of the point at which to begin drawing the text.</param>
    /// <param name="y">The y-axis coordinate of the point at which to begin drawing the text.</param>
    /// <param name="maxWidth">The maximum width the text may be once rendered. If not specified, there is no limit to the width of the text. However, if this value is provided, the user agent will adjust the kerning, select a more horizontally condensed font (if one is available or can be generated without loss of quality), or scale down to a smaller font size in order to fit the text in the specified width.</param>
    /// <returns></returns>
    public async Task StrokeText(string text, int x, int y, int maxWidth)
  => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(StrokeText).ToCamelCase()}", text, x, y, maxWidth);
    /// <inheritdoc cref="StrokeText"/>
    public async Task StrokeText(string text, int x, int y)
        => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(StrokeText).ToCamelCase()}", text, x, y);
    /// <summary>
    /// The CanvasRenderingContext2D.transform() method of the Canvas 2D API multiplies the current transformation with the matrix described by the arguments of this method. This lets you scale, rotate, translate (move), and skew the context.
    /// </summary>
    /// <param name="a">The cell in the first row and first column of the matrix.</param>
    /// <param name="b">The cell in the second row and first column of the matrix.</param>
    /// <param name="c">The cell in the first row and second column of the matrix.</param>
    /// <param name="d">The cell in the second row and second column of the matrix.</param>
    /// <param name="e">The cell in the first row and third column of the matrix.</param>
    /// <param name="f">The cell in the second row and third column of the matrix.</param>
    /// <returns></returns>
    public async Task Transform(float a, float b, float c, float d, float e, float f)
   => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(Transform).ToCamelCase()}", a, b, c, d, e, f);
    /// <summary>
    /// The translate method adds a translation transformation to the current matrix by moving the canvas and its origin x units horizontally and y units vertically on the grid.
    /// </summary>
    /// <param name="x">Distance to move in the horizontal direction. Positive values are to the right, and negative to the left.</param>
    /// <param name="y">Distance to move in the vertical direction. Positive values are down, and negative are up.</param>
    /// <returns></returns>
    public async Task Translate(int x, int y)
  => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(Translate).ToCamelCase()}", x, y);
    #endregion

    #region Property Setters
    #region internal setters
    internal async Task SetProperty(string? name, string? value)
        => await _JS.InvokeVoidAsync($"SetProperty", name, value);
    internal async Task SetProperty(string? name, float value)
        => await _JS.InvokeVoidAsync($"SetProperty", name, value);
    internal async Task SetProperty(string? name, int value)
        => await _JS.InvokeVoidAsync($"SetProperty", name, value);
    internal async Task SetPropertyValueBool(string? name, bool value)
        => await _JS.InvokeVoidAsync($"SetProperty", name, value.ToString().ToLower());
    internal async Task SetPropertyValueInPixels(string? name, int value)
        => await SetProperty(name, $"{value}px");
    #endregion

    /// <summary>
    /// Specifies the color to use inside shapes.
    /// </summary>
    /// <param name="fillStyle">The default style is #000 (black).</param>
    /// <returns></returns>
    public async Task SetFillStyle(string? fillStyle)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(fillStyle)}", fillStyle);
    /// <summary>
    /// Specifies a linear gradient to use inside shapes.
    /// </summary>
    /// <param name="filter">A linear CanvasGradient object.</param>
    public async Task SetFillStyle(LinearGradient filter)
        => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_MANAGER}.FillLinearGradient", filter.X0, filter.Y0, filter.X1, filter.Y1, filter.ColorStops);
    /// <summary>
    /// Specifies a radial gradient to use inside shapes.
    /// </summary>
    /// <param name="filter">A radial CanvasGradient object.</param>
    public async Task SetFillStyle(RadialGradient filter)
        => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_MANAGER}.FillRadialGradient", filter.X0, filter.Y0, filter.R0, filter.X1, filter.Y1, filter.R1, filter.ColorStops);
    /// <summary>
    /// Specifies a conic gradient to use inside shapes.
    /// </summary>
    /// <param name="filter">A conic CanvasGradient object.</param>
    public async Task SetFillStyle(ConicGradient filter)
        => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_MANAGER}.FillConicGradient", filter.StartAngle, filter.X, filter.Y, filter.ColorStops);
    /// <summary>
    /// Provides Gaussian blurring filter effect to the drawing.
    /// </summary>
    /// <param name="filter"></param>
    public async void SetFilter(Blur filter)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(filter)}", filter.Value);
    /// <summary>
    /// Specifies the current text style to use when drawing text. This string uses the same syntax as the CSS font specifier.
    /// </summary>
    /// <param name="font">A string parsed as CSS font value. The default font is 10px sans-serif.</param>
    /// <returns></returns>
    public async Task SetFont(string font)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(font)}", font);
    /// <summary>
    /// Specifies how font kerning information is used.Kerning adjusts how adjacent letters are spaced in a proportional font, allowing them to edge into each other's visual area if there is space available. For example, in well-kerned fonts, the characters AV, Ta and We nest together and make character spacing more uniform and pleasant to read than the equivalent text without kerning.
    /// </summary>
    /// <param name="fontKerning">The property corresponds to the font-kerning CSS property.</param>
    /// <returns></returns>
    public async Task SetFontKerning(FontKerning fontKerning)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(fontKerning)}", fontKerning.Value);
    /// <summary>
    /// Specifies how the font may be expanded or condensed when drawing text. The property corresponds to the font-stretch CSS property when used with keywords(percentage values are not supported).
    /// </summary>
    /// <param name="fontStretch">The property can be used to get or set the font stretch value.</param>
    /// <returns></returns>
    public async Task SetFontStretch(FontStretch fontStretch)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(fontStretch)}", fontStretch.Value);
    /// <summary>
    /// Specifies an alternative capitalization of the rendered text.
    /// </summary>
    /// <param name="fontVariationCap">The font alternative capitalization value</param>
    /// <returns></returns>
    public async Task SetFontVariationCap(FontVariationCap fontVariationCap)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(fontVariationCap)}", fontVariationCap.Value);
    /// <summary>
    /// Specifies the alpha (transparency) value that is applied to shapes and images before they are drawn onto the canvas.
    /// </summary>
    /// <param name="globalAlpha">A number between 0.0 (fully transparent) and 1.0 (fully opaque), inclusive. The default value is 1.0. Values outside that range, including Infinity and NaN, will not be set, and globalAlpha will retain its previous value.</param>
    /// <returns></returns>
    public async Task SetGlobalAlpha(float globalAlpha)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(globalAlpha)}", globalAlpha);
    /// <summary>
    /// Determines whether scaled images are smoothed (true, default) or not (false). On getting the imageSmoothingEnabled property, the last value it was set to is returned.This property is useful for games and other apps that use pixel art.When enlarging images, the default resizing algorithm will blur the pixels. Set this property to false to retain the pixels' sharpness.
    /// </summary>
    /// <param name="imageSmoothingEnabled ">A boolean value indicating whether to smooth scaled images or not. The default value is true.</param>
    /// <returns></returns>
    public async Task SetImageSmoothingEnabled(bool imageSmoothingEnabled)
        => await SetPropertyValueBool($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(imageSmoothingEnabled)}", imageSmoothingEnabled);
    /// <summary>
    /// The imageSmoothingQuality property of the CanvasRenderingContext2D interface, part of the Canvas API, lets you set the quality of image smoothing.
    /// </summary>
    /// <param name="imageSmoothingQuality">The default value is "low".</param>
    /// <returns></returns>
    public async Task SetImageSmoothingQuality(ImageSmoothingQuality imageSmoothingQuality)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(imageSmoothingQuality)}", imageSmoothingQuality.Value);
    /// <summary>
    /// The letter spacing as a string in the CSS length data format. The default is 0px. The property can be used to set the spacing.
    /// </summary>
    /// <param name="letterSpacing">The property value will remain unchanged if set to an invalid/unparsable value.</param>
    /// <returns></returns>
    public async Task SetLetterSpacing(int letterSpacing)
        => await SetPropertyValueInPixels($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(letterSpacing)}", letterSpacing);
    /// <summary>
    /// Determines the shape used to draw the end points of lines.
    /// </summary>
    /// <param name="lineCap"></param>
    /// <returns></returns>
    public async Task SetLineCap(LineCap lineCap)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(lineCap)}", lineCap.Value);
    /// <summary>
    /// Sets the line dash offset, or "phase."
    /// </summary>
    /// <param name="lineDashOffset">A float specifying the amount of the line dash offset. The default value is 0.0.</param>
    /// <returns></returns>
    public async Task SetLineDashOffset(float lineDashOffset)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(lineDashOffset)}", lineDashOffset);
    /// <summary>
    /// Determines the shape used to join two line segments where they meet. This property has no effect wherever two connected segments have the same direction, because no joining area will be added in this case. Degenerate segments with a length of zero(i.e., with all endpoints and control points at the exact same position) are also ignored.
    /// </summary>
    /// <param name="lineJoin">There are three possible values for this property: "round", "bevel", and "miter". The default is "miter".</param>
    /// <returns></returns>
    public async Task SetLineJoin(LineJoin lineJoin)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(lineJoin)}", lineJoin.Value);
    /// <summary>
    /// Sets the thickness of lines
    /// </summary>
    /// <param name="lineWidth">A number specifying the line width, in coordinate space units. Zero, negative, Infinity, and NaN values are ignored. This value is 1.0 by default.</param>
    /// <returns></returns>
    public async Task SetLineWidth(float lineWidth)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(lineWidth)}", lineWidth);
    /// <summary>
    /// Sets the miter limit ratio.
    /// </summary>
    /// <param name="miterLimit ">A number specifying the miter limit ratio, in coordinate space units. Zero, negative, Infinity, and NaN values are ignored. The default value is 10.0.</param>
    /// <returns></returns>
    public async Task SetMiterLimit(float miterLimit)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(miterLimit)}", miterLimit);
    /// <summary>
    /// Specifies the distance that shadows will be offset horizontally.
    /// </summary>
    /// <param name="shadowOffsetX">A float specifying the distance that shadows will be offset horizontally. Positive values are to the right, and negative to the left. The default value is 0 (no horizontal offset). Infinity and NaN values are ignored.</param>
    /// <returns></returns>
    public async Task SetShadowOffsetX(int shadowOffsetX)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(shadowOffsetX)}", shadowOffsetX);
    /// <summary>
    /// Specifies the distance that shadows will be offset vertically.
    /// </summary>
    /// <param name="shadowOffsetY">A float specifying the distance that shadows will be offset vertically. Positive values are down, and negative are up. The default value is 0 (no vertical offset). Infinity and NaN values are ignored.</param>
    /// <returns></returns>
    public async Task SetShadowOffsetY(int shadowOffsetY)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(shadowOffsetY)}", shadowOffsetY);
    /// <summary>
    /// Specifies the amount of blur applied to shadows. The default is 0 (no blur).
    /// </summary>
    /// <param name="shadowBlur">A non-negative float specifying the level of shadow blur, where 0 represents no blur and larger numbers represent increasingly more blur. This value doesn't correspond to a number of pixels, and is not affected by the current transformation matrix. The default value is 0. Negative, Infinity, and NaN values are ignored.</param>
    /// <returns></returns>
    public async Task SetShadowBlur(int shadowBlur)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(shadowBlur)}", shadowBlur);
    /// <summary>
    /// Specifies the color of shadows. Be aware that the shadow's rendered opacity will be affected by the opacity of the fillStyle color when filling, and of the strokeStyle color when stroking.
    /// </summary>
    /// <param name="color">A string parsed as a CSS color value. The default value is fully-transparent black.</param>
    /// <returns></returns>
    public async Task SetShadowColor(string color)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(color)}", color);
    /// <summary>
    /// Specifies the gradient to use for the strokes (outlines) around shapes
    /// </summary>
    /// <param name="filter">A linear CanvasGradient object.</param>
    public async Task SetStrokeStyle(LinearGradient filter)
        => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_MANAGER}.StrokeLinearGradient", filter.X0, filter.Y0, filter.X1, filter.Y1, filter.ColorStops);
    /// <summary>
    /// creates a radial gradient using the size and coordinates of two circles.
    /// </summary>
    /// <param name="filter">A radial CanvasGradient object.</param>
    public async Task SetStrokeStyle(RadialGradient filter)
        => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_MANAGER}.StrokeRadialGradient", filter.X0, filter.Y0, filter.R0, filter.X1, filter.Y1, filter.R1, filter.ColorStops);
    /// <summary>
    /// Specifies a conic gradient to use inside shapes.
    /// </summary>
    /// <param name="filter">A conic CanvasGradient object.</param>
    public async Task SetStrokeStyle(ConicGradient filter)
        => await _JS.InvokeVoidAsync($"{INTEROP_NAMES.CANVAS_MANAGER}.StrokeConicGradient", filter.StartAngle, filter.X, filter.Y, filter.ColorStops);
    /// <summary>
    /// Specifies the color to use for the strokes (outlines) around shapes. The default is #000 (black).
    /// </summary>
    /// <param name="strokeStyle">A string parsed as CSS value.</param>
    /// <returns></returns>
    public async Task SetStrokeStyle(string strokeStyle)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(strokeStyle)}", strokeStyle);
    /// <summary>
    /// Specifies the current text alignment used when drawing text.
    /// </summary>
    /// <param name="textAlign"></param>
    public async Task SetTextAlign(TextAlign textAlign)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(textAlign)}", textAlign.Value);
    /// <summary>
    /// Specifies the current text baseline used when drawing text.
    /// </summary>
    /// <param name="textBaseline"></param>
    /// <returns></returns>
    public async Task SetTextBaseline(TextBaseline textBaseline)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(textBaseline)}", textBaseline.Value);
    /// <summary>
    /// Specifies the current text direction used to draw text.
    /// </summary>
    /// <param name="textDirection"></param>
    /// <returns></returns>
    public async Task SetTextDirection(TextDirection textDirection)
        => await SetProperty($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(textDirection)}", textDirection.Value);
    /// <summary>
    /// Specifies the spacing between words when drawing text in pixels.
    /// </summary>
    /// <param name="wordSpacing">The property value will remain unchanged if set to an invalid/unparsable value.</param>
    /// <returns></returns>
    public async Task SetWordSpacing(int wordSpacing)
        => await SetPropertyValueInPixels($"{INTEROP_NAMES.CANVAS_CONTEXT2D}.{nameof(wordSpacing)}", wordSpacing);
    #endregion
    #endregion

    #region Window
    /// <summary>
    /// Returns the built-in window properties in which the script is running
    /// </summary>
    /// <param name="_js"></param>
    /// <returns></returns>
    public async Task<Window> GetWindow(IJSRuntime _js)
        => await _js.InvokeAsync<Window>("WindowInformation");
    #endregion

    #endregion
}
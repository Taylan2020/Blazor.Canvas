namespace Blazor.Canvas.Models.DOM;
/// <summary>
/// Provides current values of the elements properties: client-..., offset-..., and Scroll...
/// </summary>
public class ElementInformation
{
    /// <inheritdoc cref="ElementInformation"/>
    public ElementInformation() { }
    /// <inheritdoc cref="DOMRect"/>
    public DOMRect? BoundingClientRect { get; init; }
    /// <summary>
    /// The width of the left border of an element in pixels. It includes the width of the vertical scrollbar if the text direction of the element is right-to-left and if there is an overflow causing a left vertical scrollbar to be rendered. clientLeft does not include the left margin or the left padding. clientLeft is read-only.
    /// </summary>
    /// <remarks>This property will round the value to an integer. If you need a fractional value, use BoundingClientRect.</remarks>
    public int? ClientLeft { get; init; } = null;
    /// <summary>
    /// The width of the top border of an element in pixels. It is a read-only, integer property of element.
    /// </summary>
    /// <remarks>This property will round the value to an integer. If you need a fractional value, use BoundingClientRect.</remarks>
    public int? ClientTop { get; init; } = null;
    /// <summary>
    /// The Element.clientWidth property is zero for inline elements and elements with no CSS; otherwise, it's the inner width of an element in pixels. It includes padding but excludes borders, margins, and vertical scrollbars (if present).
    /// </summary>
    /// <remarks>This property will round the value to an integer. If you need a fractional value, use BoundingClientRect.</remarks>
    public int? ClientWidth { get; init; } = null;
    /// <summary>
    /// The Element.clientHeight read-only property is zero for elements with no CSS or inline layout boxes; otherwise, it's the inner height of an element in pixels. It includes padding but excludes borders, margins, and horizontal scrollbars (if present).
    /// </summary>
    /// <remarks>This property will round the value to an integer. If you need a fractional value, use BoundingClientRect.</remarks>
    public int? ClientHeight { get; init; } = null;
    /// <summary>
    /// The HTMLElement.offsetLeft read-only property returns the number of pixels that the upper left corner of the current element is offset to the left within the HTMLElement.offsetParent node.
    /// </summary>
    public int? OffsetLeft { get; init; } = null;
    /// <summary>
    /// The HTMLElement.offsetTop read-only property returns the distance from the outer border of the current element (including its margin) to the top padding edge of the offsetParent, the closest positioned ancestor element.
    /// </summary>
    public double? OffsetTop { get; init; } = null;
    /// <summary>
    /// The HTMLElement.offsetWidth read-only property returns the layout width of an element as an integer.
    /// </summary>
    /// <remarks>This property will round the value to an integer. If you need a fractional value, use BoundingClientRect.</remarks>
    public double? OffsetWidth { get; init; } = null;
    /// <summary>
    /// The HTMLElement.offsetHeight read-only property returns the height of an element, including vertical padding and borders, as an integer.
    /// </summary>
    /// <remarks>This property will round the value to an integer. If you need a fractional value, use BoundingClientRect.</remarks>
    public double? OffsetHeight { get; init; } = null;
    /// <summary>
    /// The Element.scrollLeft property gets or sets the number of pixels that an element's content is scrolled from its left edge. If the element's direction is rtl (right-to-left), then scrollLeft is 0 when the scrollbar is at its rightmost position (at the start of the scrolled content), and then increasingly negative as you scroll towards the end of the content.
    /// </summary>
    public double? ScrollLeft { get; init; } = null;
    /// <summary>
    /// The Element.scrollTop property gets or sets the number of pixels that an element's content is scrolled vertically. An element's scrollTop value is a measurement of the distance from the element's top to its topmost visible content.When an element's content does not generate a vertical scrollbar, then its scrollTop value is 0.
    /// </summary>
    public double? ScrollTop { get; init; } = null;
    /// <summary>
    /// The Element.scrollWidth read-only property is a measurement of the width of an element's content, including content not visible on the screen due to overflow.
    /// </summary>
    /// <remarks>This property will round the value to an integer. If you need a fractional value, use BoundingClientRect.</remarks>
    public double? ScrollWidth { get; init; } = null;
    /// <summary>
    /// The Element.scrollHeight read-only property is a measurement of the height of an element's content, including content not visible on the screen due to overflow.
    /// </summary>
    /// <remarks>This property will round the value to an integer. If you need a fractional value, use BoundingClientRect.</remarks>
    public double? ScrollHeight { get; init; } = null;
}

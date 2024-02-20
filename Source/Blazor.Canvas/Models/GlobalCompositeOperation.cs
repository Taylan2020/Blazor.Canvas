namespace Blazor.Canvas.Models;
/// <summary>
/// The CanvasRenderingContext2D.globalCompositeOperation property of the Canvas 2D API sets the type of compositing operation to apply when drawing new shapes.
/// </summary>
public record GlobalCompositeOperation
{
    internal GlobalCompositeOperation(){}

    internal string? Value { get; init; }
    /// <summary>
    /// This is the default setting and draws new shapes on top of the existing canvas content.
    /// </summary>
    public static GlobalCompositeOperation SourceOver {get;} = new()
    {
        Value = "source-over",
    };
    /// <summary>
    /// The new shape is drawn only where both the new shape and the destination canvas overlap. Everything else is made transparent.
    /// </summary>
    public static GlobalCompositeOperation SourceIn {get;} = new()
    {
        Value = "source-in",
    };
    /// <summary>
    /// The new shape is drawn where it doesn't overlap the existing canvas content.
    /// </summary>
    public static GlobalCompositeOperation SourceOut {get;} = new()
    {
        Value = "source-out",
    };
    /// <summary>
    /// The new shape is only drawn where it overlaps the existing canvas content.
    /// </summary>
    public static GlobalCompositeOperation SourceATop {get;} = new()
    {
        Value = "source-atop",
    };
    /// <summary>
    /// New shapes are drawn behind the existing canvas content.
    /// </summary>
    public static GlobalCompositeOperation DestinationOver {get;} = new()
    {
        Value = "destination-over",
    };
    /// <summary>
    /// The existing canvas content is kept where both the new shape and existing canvas content overlap. Everything else is made transparent.
    /// </summary>
    public static GlobalCompositeOperation DestinationIn {get;} = new()
    {
        Value = "destination-in",
    };
    /// <summary>
    /// The existing content is kept where it doesn't overlap the new shape.
    /// </summary>
    public static GlobalCompositeOperation DestinationOut {get;} = new()
    {
        Value = "destination-out",
    };
    /// <summary>
    /// The existing canvas is only kept where it overlaps the new shape. The new shape is drawn behind the canvas content.
    /// </summary>
    public static GlobalCompositeOperation DestinationATop {get;} = new()
    {
        Value = "destination-atop",
    };
    /// <summary>
    /// Where both shapes overlap, the color is determined by adding color values.
    /// </summary>
    public static GlobalCompositeOperation Lighter {get;} = new()
    {
        Value = "lighter",
    };
    /// <summary>
    /// Only the new shape is shown.
    /// </summary>
    public static GlobalCompositeOperation Copy {get;} = new()
    {
        Value = "copy",
    };
    /// <summary>
    /// Shapes are made transparent where both overlap and drawn normal everywhere else.
    /// </summary>
    public static GlobalCompositeOperation Xor {get;} = new()
    {
        Value = "xor",
    };
    /// <summary>
    /// The pixels of the top layer are multiplied with the corresponding pixels of the bottom layer. A darker picture is the result.
    /// </summary>
    public static GlobalCompositeOperation Multiply {get;} = new()
    {
        Value = "multiply",
    };
    /// <summary>
    /// The pixels are inverted, multiplied, and inverted again. A lighter picture is the result (opposite of multiply)
    /// </summary>
    public static GlobalCompositeOperation Screen {get;} = new()
    {
        Value = "screen",
    };
    /// <summary>
    /// A combination of multiply and screen. Dark parts on the base layer become darker, and light parts become lighter.
    /// </summary>
    public static GlobalCompositeOperation Overlay {get;} = new()
    {
        Value = "overlay",
    };
    /// <summary>
    /// Retains the darkest pixels of both layers.
    /// </summary>
    public static GlobalCompositeOperation Darken {get;} = new()
    {
        Value = "darken",
    };
    /// <summary>
    /// Retains the lightest pixels of both layers.
    /// </summary>
    public static GlobalCompositeOperation Lighten {get;} = new()
    {
        Value = "lighten",
    };
    /// <summary>
    /// Divides the bottom layer by the inverted top layer.
    /// </summary>
    public static GlobalCompositeOperation ColorDodge {get;} = new()
    {
        Value = "color-dodge",
    };
    /// <summary>
    /// Divides the inverted bottom layer by the top layer, and then inverts the result.
    /// </summary>
    public static GlobalCompositeOperation ColorBurn {get;} = new()
    {
        Value = "color-burn",
    };
    /// <summary>
    /// Like overlay, a combination of multiply and screen — but instead with the top layer and bottom layer swapped.
    /// </summary>
    public static GlobalCompositeOperation HardLight {get;} = new()
    {
        Value = "hard-light",
    };
    /// <summary>
    /// A softer version of hard-light. Pure black or white does not result in pure black or white.
    /// </summary>
    public static GlobalCompositeOperation SoftLight {get;} = new()
    {
        Value = "soft-light",
    };
    /// <summary>
    /// Subtracts the bottom layer from the top layer — or the other way round — to always get a positive value.
    /// </summary>
    public static GlobalCompositeOperation Difference {get;} = new()
    {
        Value = "difference",
    };
    /// <summary>
    /// Like difference, but with lower contrast.
    /// </summary>
    public static GlobalCompositeOperation Exclusion {get;} = new()
    {
        Value = "exclusion",
    };
    /// <summary>
    /// Preserves the luma and chroma of the bottom layer, while adopting the hue of the top layer.
    /// </summary>
    public static GlobalCompositeOperation Hue {get;} = new()
    {
        Value = "hue",
    };
    /// <summary>
    /// Preserves the luma and hue of the bottom layer, while adopting the chroma of the top layer.
    /// </summary>
    public static GlobalCompositeOperation Saturation {get;} = new()
    {
        Value = "saturation",
    };
    /// <summary>
    /// Preserves the luma of the bottom layer, while adopting the hue and chroma of the top layer.
    /// </summary>
    public static GlobalCompositeOperation Color {get;} = new()
    {
        Value = "color",
    };
    /// <summary>
    /// Preserves the hue and chroma of the bottom layer, while adopting the luma of the top layer.
    /// </summary>
    public static GlobalCompositeOperation Luminosity {get;} = new()
    {
        Value = "luminosity",
    };
}

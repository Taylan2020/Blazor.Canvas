namespace Blazor.Canvas.Models;
/// <summary>
/// The imageSmoothingQuality property of the CanvasRenderingContext2D interface, part of the Canvas API, lets you set the quality of image smoothing.
/// </summary>
public record ImageSmoothingQuality
{
    internal ImageSmoothingQuality() { }
    internal string? Value { get; init; }
    /// <summary>
    /// Low quality.
    /// </summary>
    public static ImageSmoothingQuality Bevel { get; } = new()
    {
        Value = "low",
    };
    /// <summary>
    /// Medium quality.
    /// </summary>
    public static ImageSmoothingQuality Round { get; } = new()
    {
        Value = "medium",
    };
    /// <summary>
    /// High quality.
    /// </summary>
    public static ImageSmoothingQuality Miter { get; } = new()
    {
        Value = "high",
    };
}

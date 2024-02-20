namespace Blazor.Canvas.Models.Gradient;
/// <summary>
/// Specifies the color stops, and its position along the gradient.
/// </summary>
public class ColorStop
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="offset">A number between 0 and 1, inclusive, representing the position of the color stop. 0 represents the start of the gradient and 1 represents the end.</param>
    /// <param name="color">A CSS color value representing the color of the stop.</param>
    public ColorStop(float offset, string? color)
    {
        if (offset < 0 || offset>1)
            throw new ArgumentException($"The provided {nameof(offset)} value ({offset}) is outside the range (0.0, 1.0).");

        Offset = offset;
        Color = color;
    }

    /// <summary>
    /// A number between 0 and 1, inclusive, representing the position of the color stop. 0 represents the start of the gradient and 1 represents the end.
    /// </summary>
    public float Offset { get; init; }
    /// <summary>
    /// A CSS color value representing the color of the stop.
    /// </summary>
    public string? Color { get; init; }
}

namespace Blazor.Canvas.Models.Filter;
/// <summary>
/// The blur() CSS function applies a Gaussian blur to the input image. Its result is a filter-function.
/// </summary>
public class Blur:Filter
{
    /// <summary>
    /// he blur() function applies a Gaussian blur to the elements on which it is applied.
    /// </summary>
    /// <param name="radiusInPixels">The radius of the blur, specified as a length. It defines the value of the standard deviation to the Gaussian function, i.e., how many pixels on the screen blend into each other; thus, a larger value will create more blur. A value of 0 leaves the input unchanged. The initial value for interpolation is 0.</param>
    public void SetBlurWithUnitPixel(int radiusInPixels)
        =>Value = $"{radiusInPixels}px";
    /// <summary>
    /// he blur() function applies a Gaussian blur to the elements on which it is applied.
    /// </summary>
    /// <param name="radiusInREM">The radius of the blur, specified as a length. It defines the value of the standard deviation to the Gaussian function, i.e., how many rems on the screen blend into each other; thus, a larger value will create more blur. A value of 0 leaves the input unchanged. The initial value for interpolation is 0.</param>
    public void SetBlurWithUnitREM(float radiusInREM)
        =>Value = $"{radiusInREM}rem";
    
}

namespace Blazor.Canvas.Models.DOM;
/// <summary>
/// Interface for HTML Elements
/// </summary>
internal interface IElement
{
    /// <summary>
    /// Defines an identifier (ID) for the element which must be unique in the whole document.
    /// </summary>
    internal abstract string? Id { get; init; }
    /// <summary>
    /// Defines a name for the element.
    /// </summary>
    internal abstract string? Name { get; init; }
    /// <summary>
    /// A string variable representing the class or space-separated classes of the element.
    /// </summary>
    internal abstract string? Class { get; set; }
    /// <summary>
    /// Assigns a unique style to the element
    /// </summary>
    internal abstract string? Style { get; set; }
}

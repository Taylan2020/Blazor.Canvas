namespace Blazor.Canvas.Models.DOM;

internal interface IElement
{
    internal abstract string? Id { get; init; }
    internal abstract string? Name { get; init; }
    internal abstract string? Class { get; set; }
    internal abstract string? Style { get; set; }
}

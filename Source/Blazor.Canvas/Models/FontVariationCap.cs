namespace Blazor.Canvas.Models;
/// <summary>
/// The CanvasRenderingContext2D.fontVariantCaps property of the Canvas API specifies an alternative capitalization of the rendered text.
/// </summary>
public record FontVariationCap
{
    internal FontVariationCap() { }
    internal string? Value { get; init; }
    /// <summary>
    /// Deactivates of the use of alternate glyphs.
    /// </summary>
    public static FontVariationCap Normal {get;} = new()
    {
        Value = "normal",
    };
    /// <summary>
    /// Enables display of small capitals (OpenType feature: smcp). Small-caps glyphs typically use the form of uppercase letters but are reduced to the size of lowercase letters.
    /// </summary>
    public static FontVariationCap SmallCaps {get;} = new()
    {
        Value = "small-caps",
    };
    /// <summary>
    /// Enables display of small capitals for both upper and lowercase letters (OpenType features: c2sc, smcp).
    /// </summary>
    public static FontVariationCap AllSmallCaps {get;} = new()
    {
        Value = "all-small-caps",
    };
    /// <summary>
    /// Enables display of petite capitals (OpenType feature: pcap).
    /// </summary>
    public static FontVariationCap PetiteCaps {get;} = new()
    {
        Value = "petite-caps",
    };
    /// <summary>
    /// Enables display of petite capitals for both upper and lowercase letters (OpenType features: c2pc, pcap).
    /// </summary>
    public static FontVariationCap AllPetiteCaps {get;} = new()
    {
        Value = "all-petite-caps",
    };
    /// <summary>
    /// Enables display of mixture of small capitals for uppercase letters with normal lowercase letters (OpenType feature: unic).
    /// </summary>
    public static FontVariationCap Unicase {get;} = new()
    {
        Value = "unicase",
    };
    /// <summary>
    /// Enables display of titling capitals (OpenType feature: titl). Uppercase letter glyphs are often designed for use with lowercase letters. When used in all uppercase titling sequences they can appear too strong. Titling capitals are designed specifically for this situation.
    /// </summary>
    public static FontVariationCap TitlingCaps { get; } = new()
    {
        Value = "titling-caps",
    };
}

namespace Blazor.Canvas.Models.DOM;

/// <summary>
/// The Window.location read-only property returns a Location object with information about the current location of the document.
/// </summary>
public class Location
{
    /// <inheritdoc cref="Location"></inheritdoc>
    public Location() { }
    /// <summary>
    /// The hash property of the Location interface returns a string containing a '#' followed by the fragment identifier of the URL — the ID on the page that the URL is trying to target. The fragment is not URL decoded.If the URL does not have a fragment identifier, this property contains an empty string, "".
    /// </summary>
    public string? Hash { get; init; }
    /// <summary>
    /// The host property of the Location interface is a string containing the host, that is the hostname, and then, if the port of the URL is nonempty, a ':', and the port of the URL.
    /// </summary>
    public string? Host { get; init; }
    /// <summary>
    /// The hostname property of the Location interface is a string containing the domain of the URL.
    /// </summary>
    public string? HostName { get; init; }
    /// <summary>
    /// The href property of the Location interface is a stringifier that returns a string containing the whole URL, and allows the href to be updated. Setting the value of href navigates to the provided URL.If you want redirection, use location.replace(). The difference from setting the href property value is that when using the location.replace() method, after navigating to the given URL, the current page will not be saved in session history — meaning the user won't be able to use the back button to navigate to it.
    /// </summary>
    public string? Href { get; init; }
    /// <summary>
    /// The origin read-only property of the Location interface is a string containing the Unicode serialization of the origin of the represented URL.
    /// </summary>
    public string? Origin { get; init; }
    /// <summary>
    /// The pathname property of the Location interface is a string containing the path of the URL for the location. If there is no path, pathname will be empty: otherwise, pathname contains an initial '/' followed by the path of the URL, not including the query string or fragment.
    /// </summary>
    public string? PathName { get; init; }
    /// <summary>
    /// The port property of the Location interface is a string containing the port number of the URL. If the URL does not contain an explicit port number, it will be set to ''.
    /// </summary>
    public string? Port { get; init; }
    /// <summary>
    /// The protocol property of the Location interface is a string representing the protocol scheme of the URL, including the final ':'.
    /// </summary>
    public string? Protocol { get; init; }
    /// <summary>
    /// The search property of the Location interface is a search string, also called a query string; that is, a string containing a '?' followed by the parameters of the URL.
    /// </summary>
    public string? Search { get; init; }
}

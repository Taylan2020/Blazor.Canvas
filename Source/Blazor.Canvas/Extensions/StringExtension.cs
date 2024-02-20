using System.Text.RegularExpressions;

namespace Blazor.Canvas.Extensions;

internal static class StringExtension
{
    public static string? ToCamelCase(this string? value)
    {
        if (string.IsNullOrEmpty(value))
            return null;

        return Regex.Replace(value, @"([A-Z])([A-Z]+|[a-z0-9_]+)($|[A-Z]\w*)",
        m =>
        {
            return m.Groups[1].Value.ToLower() + m.Groups[2].Value.ToLower() + m.Groups[3].Value;
        });
    }
}

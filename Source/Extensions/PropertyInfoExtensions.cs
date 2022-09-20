using System.Reflection;

namespace Source.Extensions;

public static class PropertyInfoExtensions
{
    public static string GetValueString(this PropertyInfo source, object? obj) =>
        source.GetValue(obj)?.ToString() ?? string.Empty;
}
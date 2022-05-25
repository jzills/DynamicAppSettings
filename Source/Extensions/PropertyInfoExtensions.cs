using System.Reflection;

namespace DynamicAppSettings.Extensions;

public static class PropertyInfoExtensions
{
    public static string GetValueString(this PropertyInfo source, object? obj) =>
        source.GetValue(obj)?.ToString() ?? string.Empty;
}
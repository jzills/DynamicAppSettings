namespace DynamicAppSettings.Extensions;

public static class ArrayExtensions
{
    public static string GetElementsAsString(this Array source, string delimiter = ", ")
    {
        var result = string.Empty;
        foreach (var sourceValue in source)
            result += $"{sourceValue.ToString()}{delimiter}";

        return result.Substring(0, result.LastIndexOf(delimiter));
    }
}
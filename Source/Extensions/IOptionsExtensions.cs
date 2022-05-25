using System.Reflection;
using Microsoft.Extensions.Options;

namespace DynamicAppSettings.Extensions;

public static class IOptionsExtensions
{
    public static IEnumerable<KeyValuePair<string, string>> AsEnumerable<T>(this IOptions<T> source) where T : class =>
        source
            .Value
            .GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Select(property => new KeyValuePair<string, string>(
                property.Name,
                property.GetValue(source.Value)?.ToString() ?? string.Empty
            ));

    public static void ToScopeDictionary<T>(T source, string scope, Dictionary<string, string> dictionary)
	{
		var properties = source.GetType().GetProperties();

        foreach (var property in properties)
        {
            var formattedScope = FormatScope(scope, property.Name);
            if (property.PropertyType == typeof(string))
                dictionary.Add(
                    formattedScope, 
                    property.GetValue(source)?.ToString() ?? string.Empty
                );
			else if (property.PropertyType.IsArrayOrEnumerable())
			{
				//TODO: Handle array types
			}
			else if (property.PropertyType.BaseType == typeof(object))
                ToScopeDictionary(
                    property.GetValue(source), 
                    formattedScope, 
                    dictionary
                );
        }

        string FormatScope(params string[] scopes) => string.Join(":", scopes);
	}
}
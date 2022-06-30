using Microsoft.Extensions.Options;

namespace DynamicAppSettings.Extensions;

public static class IOptionsExtensions
{
    public static IList<KeyValuePair<string, string>> ToScopeDictionary<T>(this IOptions<T> source) where T : class
    {
        var result = new Dictionary<string, string>();
        var typeName = source.Value.GetType().Name;
        source.Value.ToScopeDictionary(typeName, result);
        return result.ToList();
    }

    private static void ToScopeDictionary<T>(this T source, string scope, Dictionary<string, string> dictionary)
	{
		var properties = source?.GetType()?.GetProperties();
        if (properties != null)
        {
            foreach (var property in properties)
            {
                var formattedScope = FormatScope(scope, property.Name);
                if (property.PropertyType == typeof(string))
                {
                    dictionary.Add(formattedScope, property.GetValueString(source));
                }
                else if (property.PropertyType.IsArrayOrEnumerable())
                {
                    var arrayValue = (Array?) property.GetValue(source);
                    if (arrayValue != null)
                    {
                        dictionary.Add(formattedScope, arrayValue.GetElementsAsString());
                    }
                }
                else if (property.PropertyType.BaseType == typeof(object))
                {
                    ToScopeDictionary(property.GetValue(source), formattedScope, dictionary);
                }
                else
                {
                    dictionary.Add(formattedScope, property.GetValueString(source));
                }
            }
        }
        
        string FormatScope(params string[] scopes) => string.Join(":", scopes);
	}
}
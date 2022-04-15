using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;

namespace DynamicAppSettings.Extensions
{
    public static class IOptionsExtensions
    {
        public static IEnumerable<KeyValuePair<string, string>> AsEnumerable<T>(this IOptions<T> source) where T : class =>
            source
                .GetType()
                .GetProperties()
                .Select(property => new KeyValuePair<string, string>(
                    property.Name, 
                    property.GetValue(source).ToString()
                ));
    }
}
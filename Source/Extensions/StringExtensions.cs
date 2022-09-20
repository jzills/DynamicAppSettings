using System.Text.Json;

namespace Source.Extensions;

public static class StringExtensions
{
    public static bool TryGetJsonObject(this string serializedJson, out Dictionary<string, object> deserializedJson)
    {
        #pragma warning disable CS8625, CS8601

        deserializedJson = null;
        if (serializedJson.StartsWith("{") && serializedJson.EndsWith("}"))
        {
            try
            {
                deserializedJson = JsonSerializer.Deserialize<Dictionary<string, object>>(serializedJson);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        return false;

        #pragma warning restore CS8625, CS8601
    }
}
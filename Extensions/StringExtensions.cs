using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DynamicAppSettings.Extensions;

public static class StringExtensions
{
    public static bool TryGetJsonObject(this string serializedJson, out Dictionary<string, object> deserializedJson)
    {
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
    }
}
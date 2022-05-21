namespace DynamicAppSettings.Configurations;

public class ApiOptions
{
    public string BaseUrl { get; set; }
    public ApiAuthenticationOptions Authentication { get; set; }
}

public class ApiAuthenticationOptions
{
    public string Key { get; set; }
    public string Secret { get; set; }
}
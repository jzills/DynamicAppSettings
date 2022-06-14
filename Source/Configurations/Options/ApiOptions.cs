namespace DynamicAppSettings.Configurations;

#pragma warning disable CS8618

public class ApiOptions
{
    public string BaseUrl { get; set; }
    
    public AuthenticationOptions Authentication { get; set; }
}
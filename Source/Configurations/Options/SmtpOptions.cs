namespace DynamicAppSettings.Configurations;

#pragma warning disable CS8618

public class SmtpOptions
{
    public string Host { get; set; }
    public int Port { get; set; }
    public bool EnableSSL { get; set; }
}
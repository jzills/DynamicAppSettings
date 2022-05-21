namespace DynamicAppSettings.Configurations;

public class SmtpOptions
{
    public string Host { get; set; }
    public int Port { get; set; }
    public bool EnableSSL { get; set; }
}
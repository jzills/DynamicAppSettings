using System.ComponentModel.DataAnnotations;

namespace DynamicAppSettings.Data;

#pragma warning disable CS8618

public class AppSetting
{
    [Key]
    public Guid Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public bool IsJsonValue { get; set; }
}
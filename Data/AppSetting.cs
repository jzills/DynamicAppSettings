using System;
using System.ComponentModel.DataAnnotations;

namespace DynamicAppSettings.Data
{
    public class AppSetting
    {
        [Key]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool IsJsonValue { get; set; }
    }
}
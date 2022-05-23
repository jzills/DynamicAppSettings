using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using DynamicAppSettings.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DynamicAppSettings.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
     : base(options) { }

    public virtual DbSet<AppSetting> AppSettings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<AppSetting>()
            .HasData(GetAppSettings().Concat(GetAppSettingsWithJsonValue()));
    }

    private List<AppSetting> GetAppSettings() =>
        new List<AppSetting>
        {
            new AppSetting
            {
                Id = Guid.NewGuid(),
                Key = "Api:BaseUrl",
                Value = "www.someapi.com/api",
                IsJsonValue = false
            },
            new AppSetting
            {
                Id = Guid.NewGuid(),
                Key = "Api:Authentication:Key",
                Value = Guid.NewGuid().ToString(),
                IsJsonValue = false
            },
            new AppSetting
            {
                Id = Guid.NewGuid(),
                Key = "Api:Authentication:Secret",
                Value = Guid.NewGuid().ToString(),
                IsJsonValue = false
            }
        };

    private List<AppSetting> GetAppSettingsWithJsonValue() =>
        new List<AppSetting>
        {
            new AppSetting
            {
                Id = Guid.NewGuid(),
                Key = "Smtp",
                Value = JsonSerializer.Serialize(new SmtpOptions
                {
                    Port = 3030,
                    Host = "Some Host",
                    EnableSSL = true
                }),
                IsJsonValue = true
            },
            new AppSetting
            {
                Id = Guid.NewGuid(),
                Key = "ApiOther",
                Value = JsonSerializer.Serialize(new ApiOtherOptions
                {
                    BaseUrl = "www.someotherapi.com/api",
                    Authentication = new AuthenticationOptions
                    {
                        Key = Guid.NewGuid().ToString(),
                        Secret = Guid.NewGuid().ToString()
                    }
                }),
                IsJsonValue = true
            }
        };
}
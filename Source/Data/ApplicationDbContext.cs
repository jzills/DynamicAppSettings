using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Source.Configurations;

namespace Source.Data;

#pragma warning disable CS8618

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
                Key = "ApiOptions:BaseUrl",
                Value = "www.someapi.com/api",
                IsJsonValue = false
            },
            new AppSetting
            {
                Id = Guid.NewGuid(),
                Key = "ApiOptions:Authentication:Key",
                Value = Guid.NewGuid().ToString(),
                IsJsonValue = false
            },
            new AppSetting
            {
                Id = Guid.NewGuid(),
                Key = "ApiOptions:Authentication:Secret",
                Value = Guid.NewGuid().ToString(),
                IsJsonValue = false
            },
            new AppSetting
            {
                Id = Guid.NewGuid(),
                Key = "AuthenticationOptions:Key",
                Value = Guid.NewGuid().ToString(),
                IsJsonValue = false
            },
            new AppSetting
            {
                Id = Guid.NewGuid(),
                Key = "AuthenticationOptions:Secret",
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
                Key = "SmtpOptions",
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
                Key = "ApiOtherOptions",
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
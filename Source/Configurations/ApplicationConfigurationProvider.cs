using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using DynamicAppSettings.Data;
using DynamicAppSettings.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DynamicAppSettings.Configurations;

public class ApplicationConfigurationProvider : ConfigurationProvider
{
    public ApplicationConfigurationProvider(IConfiguration configuration) =>
        Configuration = configuration;

    public IConfiguration Configuration { get; }

    public override void Load()
    {
        using var context = new ApplicationDbContext(GetDbContextOptions());
        context.Database.EnsureCreated();

        ConfigureOptions(context.AppSettings.Where(appSetting => !appSetting.IsJsonValue));
        ConfigureOptionsWithJsonValues(context.AppSettings.Where(appSetting => appSetting.IsJsonValue));
    }

    private void ConfigureOptions(IQueryable<AppSetting> appSettings)
    {
        foreach (var appSetting in appSettings)
            Data.Add(appSetting.Key, appSetting.Value);
    }

    private void ConfigureOptionsWithJsonValues(IQueryable<AppSetting> appSettings)
    {
        foreach (var appSetting in appSettings)
            BuildAppSettingsFromJsonValue(appSetting.Key, appSetting.Value);
    }

    private void BuildAppSettingsFromJsonValue(string key, string jsonValue)
    {
        if (jsonValue.TryGetJsonObject(out var deserializedJson))
        {
            foreach (var _key in deserializedJson.Keys)
            {
                var serializedJson = JsonSerializer.Serialize(deserializedJson[_key]);
                if (serializedJson.TryGetJsonObject(out Dictionary<string, object> _))
                    BuildAppSettingsFromJsonValue($"{key}:{_key}", serializedJson);
                else
                    Data.Add($"{key}:{_key}", deserializedJson[_key].ToString());
            }
        }
        else throw new FormatException("The specified JSON is invalid.");
    }

    private DbContextOptions<ApplicationDbContext> GetDbContextOptions() =>
        new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Configuration["DbConnection"])
            .Options;
}
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using DynamicAppSettings.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DynamicAppSettings.Configurations
{
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

        private void ConfigureOptions(IQueryable<AppSetting> dbSet)
        {
            foreach (var appSetting in dbSet)
                Data.Add(appSetting.Key, appSetting.Value);
        }

        private void ConfigureOptionsWithJsonValues(IQueryable<AppSetting> dbSet)
        {
            var appSettings = dbSet.ToDictionary(
                setting => setting.Key, 
                setting => JsonSerializer.Deserialize<Dictionary<string, object>>(setting.Value)
            );

            foreach (var key in appSettings.Keys)
                foreach (var keyValuePair in appSettings[key])
                    Data.Add($"{key}:{keyValuePair.Key}", $"{keyValuePair.Value}");
        }

        private DbContextOptions<ApplicationDbContext> GetDbContextOptions() =>
            new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Configuration["DbConnection"])
                .Options;
    }
}
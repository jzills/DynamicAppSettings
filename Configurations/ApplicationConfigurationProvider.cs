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

            var appSettings = context.AppSettings.ToDictionary(
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
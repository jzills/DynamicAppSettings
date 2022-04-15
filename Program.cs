using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using DynamicAppSettings.Configurations;

namespace DynamicAppSettings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .ConfigureAppConfiguration((context, configuration) => 
                {
                    configuration.Add(new ApplicationConfigurationSource(configuration.Build()));
                })
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

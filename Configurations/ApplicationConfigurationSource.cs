using Microsoft.Extensions.Configuration;

namespace DynamicAppSettings.Configurations
{
    public class ApplicationConfigurationSource : IConfigurationSource
    {
        public ApplicationConfigurationSource(IConfiguration configuration) => 
            Configuration = configuration;
        
        public IConfiguration Configuration { get; }

        public IConfigurationProvider Build(IConfigurationBuilder builder) =>
            new ApplicationConfigurationProvider(Configuration);
    }
}
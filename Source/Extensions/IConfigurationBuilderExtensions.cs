using DynamicAppSettings.Configurations;

namespace DynamicAppSettings.Extensions;

public static class IConfigurationBuilderExtensions
{
    public static void AddApplicationConfiguration(this IConfigurationBuilder builder) =>
        builder.Add(new ApplicationConfigurationSource(builder.Build()));
}
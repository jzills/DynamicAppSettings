# Dynamic App Settings

## TL;DR
Inherit from IConfigurationSource and return a custom class that inherits ConfigurationProvider to create a custom provider. Use the [Load](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.configurationprovider.load?view=dotnet-plat-ext-6.0) method to store key/value pairs in the providers [Data](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.configurationprovider.data?view=dotnet-plat-ext-6.0) property.

## Summary
This example shows how to store settings for an ASP.NET Core in as database entries. The settings are fetched during startup using custom configuration providers and can be then used for the lifetime of the application either by binding models using the IOptions pattern or read directly from the IConfiguration interface.

## Database Configuration
There are two methods used in this example for storing appsettings values in the seed database. Both methods assume a table with at a minimum of key and value VARCHAR columns. The first method stores the key as the name of the model to be bound to and recursively builds the data in the ApplicationConfigurationProvider. The other method stores the key already in the format expected by a configuration provider, i.e. nested object keys are expected as colon separated.

### Database Configuration Example
The first method would store the entire JSON object below as the value whereas the second method would use the below values for keys.
```javascript
{
    ApiOptions: {
        BaseUrl: "www.someapi.com/api",
        Authentication: {
            Key: "1a3ef0e5-3b51-4fd1-9920-f83616e19096",
            Secret: "31699706-87aa-4012-b525-fa4d90ee5991"
        }
    }
}
```

```c#
new AppSetting
{
    Key = "ApiOptions:BaseUrl",
    Value = "www.someapi.com/api"
},
new AppSetting
{
    Key = "ApiOptions:Authentication:Key",
    Value = "1a3ef0e5-3b51-4fd1-9920-f83616e19096"
},
new AppSetting
{
    Key = "ApiOptions:Authentication:Secret",
    Value = "31699706-87aa-4012-b525-fa4d90ee5991"
}
```

## More information from Microsoft
[Custom Configuration Provider](https://docs.microsoft.com/en-us/dotnet/core/extensions/custom-configuration-provider)

[IOptions](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0)

[Configuration](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-6.0)

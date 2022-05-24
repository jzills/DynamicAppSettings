using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DynamicAppSettings.Configurations;
using DynamicAppSettings.Data;

namespace DynamicAppSettings.Controllers;

[Route("configuration")]
public class ConfigurationController : Controller
{
    private readonly SmtpOptions _smtpOptions;
    private readonly ApiOptions _apiOptions;
    private readonly ApiOtherOptions _apiOtherOptions;

    // TODO: IOptionsSnapshot for reloading 
    public ConfigurationController(
        IOptions<SmtpOptions> smtpOptions,
        IOptions<ApiOptions> apiOptions,
        IOptions<ApiOtherOptions> apiOtherOptions
    )
    {
        _smtpOptions = smtpOptions.Value;
        _apiOptions = apiOptions.Value;
        _apiOtherOptions = apiOtherOptions.Value;
    }

    [HttpGet]
    [Route("{type}")]
    public IActionResult Get(ConfigurationTypes type = ConfigurationTypes.SmtpOptions) =>
        Ok(type switch
        {
            ConfigurationTypes.SmtpOptions      => _smtpOptions,
            ConfigurationTypes.ApiOptions       => _apiOptions,
            ConfigurationTypes.ApiOtherOptions  => _apiOtherOptions,
            _                                   => throw new NotSupportedException("Unsupported configuration type.")
        });

    [HttpGet]
    [Route("types")]
    public IActionResult GetTypes() => Ok(new[] 
    {
        new 
        {
            Id = ConfigurationTypes.ApiOptions,
            Name = nameof(ConfigurationTypes.ApiOptions)
        },
        new 
        {
            Id = ConfigurationTypes.ApiOtherOptions,
            Name = nameof(ConfigurationTypes.ApiOtherOptions)
        },
        new 
        {
            Id = ConfigurationTypes.IConfiguration,
            Name = nameof(ConfigurationTypes.IConfiguration)
        },
        new 
        {
            Id = ConfigurationTypes.SmtpOptions,
            Name = nameof(ConfigurationTypes.SmtpOptions)
        }
    });
}
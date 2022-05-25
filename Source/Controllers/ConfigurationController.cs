using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DynamicAppSettings.Configurations;
using DynamicAppSettings.Data;
using DynamicAppSettings.Extensions;

namespace DynamicAppSettings.Controllers;

[Route("configuration")]
public class ConfigurationController : Controller
{
    private readonly IOptions<SmtpOptions> _smtpOptions;
    private readonly IOptions<ApiOptions> _apiOptions;
    private readonly IOptions<ApiOtherOptions> _apiOtherOptions;

    // TODO: IOptionsSnapshot for reloading 
    public ConfigurationController(
        IOptions<SmtpOptions> smtpOptions,
        IOptions<ApiOptions> apiOptions,
        IOptions<ApiOtherOptions> apiOtherOptions
    )
    {
        _smtpOptions = smtpOptions;
        _apiOptions = apiOptions;
        _apiOtherOptions = apiOtherOptions;
    }

    [HttpGet]
    [Route("{type}")]
    public IActionResult Get(ConfigurationTypes type = ConfigurationTypes.SmtpOptions) =>
        Ok(type switch
        {
            ConfigurationTypes.SmtpOptions      => _smtpOptions.ToScopeDictionary(),
            ConfigurationTypes.ApiOptions       => _apiOptions.ToScopeDictionary(),
            ConfigurationTypes.ApiOtherOptions  => _apiOtherOptions.ToScopeDictionary(),
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
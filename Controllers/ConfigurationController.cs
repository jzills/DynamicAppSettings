using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DynamicAppSettings.Configurations;
using DynamicAppSettings.Extensions;
using DynamicAppSettings.Data;

namespace DynamicAppSettings.Controllers;

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

    public IActionResult Get(ConfigurationTypes type) =>
        Ok(type switch
        {
            ConfigurationTypes.SmtpOptions      => _smtpOptions,
            ConfigurationTypes.ApiOptions       => _apiOptions,
            ConfigurationTypes.ApiOtherOptions  => _apiOtherOptions,
            _                                   => throw new NotSupportedException("Unsupported configuration type.")
        });
}
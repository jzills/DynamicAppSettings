using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using DynamicAppSettings.Configurations;
using DynamicAppSettings.Extensions;
using DynamicAppSettings.Data;
using System.Linq;

namespace DynamicAppSettings.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IOptions<SmtpOptions> _smtpOptions;
        private readonly IOptions<ApiOptions> _apiOptions;
        private readonly IOptions<ApiOtherOptions> _apiOtherOptions;

        public HomeController(
            IConfiguration configuration,
            IOptions<SmtpOptions> smtpOptions,
            IOptions<ApiOptions> apiOptions,
            IOptions<ApiOtherOptions> apiOtherOptions
        )
        {
            _configuration = configuration;
            _smtpOptions = smtpOptions;   
            _apiOptions = apiOptions;
            _apiOtherOptions = apiOtherOptions;
        }

        public IActionResult Index(ConfigurationTypes type)
        {
            
            ViewBag.Result = type switch
            {
                ConfigurationTypes.IConfiguration   => _configuration.AsEnumerable(),
                ConfigurationTypes.SmtpOptions      => _smtpOptions.AsEnumerable(),
                ConfigurationTypes.ApiOptions       => _apiOptions.AsEnumerable(),
                ConfigurationTypes.ApiOtherOptions  => _apiOtherOptions.AsEnumerable(),
                _                                   => null
            };

            return View();
        }
    }
}
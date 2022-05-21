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

        public HomeController(
            IConfiguration configuration,
            IOptions<SmtpOptions> smtpOptions,
            IOptions<ApiOptions> apiOptions
        )
        {
            _configuration = configuration;
            _smtpOptions = smtpOptions;   
            _apiOptions = apiOptions;
        }

        public IActionResult Index(ConfigurationTypes type)
        {
            
            ViewBag.Result = type switch
            {
                ConfigurationTypes.IConfiguration   => _configuration.AsEnumerable(),
                ConfigurationTypes.SmtpOptions      => _smtpOptions.AsEnumerable(),
                ConfigurationTypes.ApiOptions       => _apiOptions.AsEnumerable(),
                _                                   => null
            };

            return View();
        }
    }
}
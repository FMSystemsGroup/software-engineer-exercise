using FMSystems.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;
using Serilog;
using FMSystems.Server.Support;
using FMSystems.Services;
using FMSystems.Services.Interfaces;
using FMSystems.Shared.DTO;
using Microsoft.AspNetCore.Http;

namespace FMSystems.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {

        private readonly AppSettings appSettings;


        public AdminController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

      
        /// <summary>
        /// Checks to see if the Dark Sky API key is configured
        /// </summary>
        /// <returns>true if the key was configured in a key vault or appsettings</returns>
        [Route("IsKeyAvailable")]
        [HttpGet]
        public bool IsKeyAvailable()
        {
            bool keyIsPresent = false;

            try
            {
                keyIsPresent = !string.IsNullOrEmpty(appSettings.DarkSkyApiKey);
            }
            catch
            {
                keyIsPresent = false;
            }

            return keyIsPresent;


        }

    }
}

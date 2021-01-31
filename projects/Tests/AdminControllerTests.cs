using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FMSystems.Server;
using FMSystems.Server.Controllers;
using FMSystems.Server.Support;
using FMSystems.Services;
using FMSystems.Services.Interfaces;
using FMSystems.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FMSystems.Tests
{
    public class AdminControllerTests
    {


        [Fact(DisplayName = "No Api Key Configured: Success when no value")]
        public void CheckApiKeyMissingReturnFalse()
        {
            var mockOptions = new OptionsWrapper<AppSettings>(new AppSettings
            {
                DarkSkyApiKey = null
            });

            var controller = new AdminController(mockOptions);

            var retVal =  controller.IsKeyAvailable();
            var bResult = Assert.IsType<bool>(retVal);
            Assert.False(retVal);
        }


        [Fact(DisplayName = "Api Key is Configured: Success when there is a value")]
        public void CheckApiKeyConfiguredReturnTrue()
        {
            var mockOptions = new OptionsWrapper<AppSettings>(new AppSettings
            {
                DarkSkyApiKey = "SOMEKEYVALUE"
            });

            var controller = new AdminController(mockOptions);

            var retVal =  controller.IsKeyAvailable();
            var bResult = Assert.IsType<bool>(retVal);
            Assert.True(retVal);


        }
    }
}

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
using FMSystems.Services.Repository.Interfaces;
using FMSystems.Services.Repository;

namespace FMSystems.Tests
{
    public class CityServiceTests
    {


        [Fact(DisplayName = "Get City List Successfully")]
        public async Task GetCityListSuccess()
        {
            var mockOptions = new OptionsWrapper<AppSettings>(new AppSettings
            {
                DarkSkyApiKey = null
            });

            List<City> cityList = CityRepository.MockCityData.ToList();

            var mockRepos = new  Mock<ICityRepository>();
            mockRepos.Setup(repo => repo.GetCities()).Returns(Task.FromResult<List<City>>(cityList));

            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(repo => repo.Cities.GetCities()).Returns(Task.FromResult<List<City>>(cityList));


            var sut = new CityService(mockUOW.Object);

            var result = await sut.GetCities();

            Assert.IsType<List<City>>(result);
        }
    }
}

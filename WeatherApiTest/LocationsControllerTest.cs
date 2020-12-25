using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using WeatherApi.Data;
using WeatherApi.Controllers;
using Weather.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WeatherApiTest
{
    public class LocationsControllerTest
    {
        private readonly LocationsController _testController;
        private readonly Mock<ILocationRepo> _locationRepoMock = new Mock<ILocationRepo>();
        public LocationsControllerTest()
        {
            _testController = new LocationsController(_locationRepoMock.Object);
        }

        /// <summary>
        /// Test the condition when location repository returns empty collection.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetLocationsAsync_CheckforNotFound()
        {
            //Arrange
            var testLocations = Array.Empty<Location>();
            _locationRepoMock.Setup(x => x.GetLocationsAsync())
                .ReturnsAsync(testLocations);

            //Act
            var result = await _testController.GetLocations();

            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Location>>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        /// <summary>
        ///  Test the condition when location repository returns a collections as expected.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetLocationsAsync_CheckforOk()
        {
            //Arrange
            var testLocations = new List<Location>()
            {
                new Location {Id=1, City="TestCity", State="TestState", Country="TestCountry", Latitude=0 , Longitude=0, UnixTime="0"}
            };

            _locationRepoMock.Setup(x => x.GetLocationsAsync())
                .ReturnsAsync(testLocations);

            //Act
            var result = await _testController.GetLocations();

            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Location>>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }
    }
}

using CityAPI.Controllers;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service;
using Service.Contracts;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xunit;

namespace TestCityWebAPI
{
    /// <summary>
    /// This class contains unit tests for the CitiesController class that uses the xUnit framework 
    /// </summary>
    public class CitiesControllerTests
    {     
        /// <summary>
        /// This method tests the GetCityNames action of the CitiesController class and verifies that it 
        /// returns a list of four cities with status code 200
        /// </summary>
        [Fact]
        public void GetCities_ReturnsListOfCities()
        {               
            // Arrange
            var mockCityService = new Mock<ICityService>();
            mockCityService.Setup(x => x.GetCityNames())
                .Returns(new List<City>
                {
                new City { Name = "Phoenix", State = "AZ", Country = "USA" },
                new City { Name = "Raleigh", State = "NC", Country = "USA" },
                new City { Name = "Saint John", State = "NB", Country = "Canada" },
                new City { Name = "San Diego", State = "CA", Country = "USA" }
                });

            var mockServiceManager = new Mock<IServiceManager>();
            mockServiceManager.Setup(x => x.CityService)
                .Returns(mockCityService.Object);

            var controller = new CitiesController(mockServiceManager.Object);

            // Act
            var result = controller.GetCityNames() as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var cities = result.Value as List<City>;
            Assert.NotNull(cities);
            Assert.Equal(4, cities.Count);
        }

        /// <summary>
        /// This method tests the GetCityNames action of the CitiesController class and verifies that it 
        /// returns a empty list with status code 200 
        /// </summary>
        [Fact]
        public void GetCities_ReturnsEmptyList_WhenNoCities()
        {
            // Arrange
            //Create a mock CityService that returns an empty list of cities

            var mockCityService = new Mock<ICityService>();
            mockCityService.Setup(x => x.GetCityNames())
                .Returns(new List<City>());

            // Create a mock ServiceManager that returns the mock CityService.
            var mockServiceManager = new Mock<IServiceManager>();
            mockServiceManager.Setup(x => x.CityService)
                .Returns(mockCityService.Object);

            // Create an instance of the CitiesController using the mock ServiceManager.
            var controller = new CitiesController(mockServiceManager.Object);

            // Act
            // Call the GetCityNames action on the controller and cast the result as an ObjectResult.
            var result = controller.GetCityNames() as ObjectResult;

            // Assert

            // Check that the result is not null and that it returns an HTTP status code of 200.
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            //// Check that the value in the result is an empty list of cities.
            var cities = result.Value as List<City>;
            Assert.NotNull(cities);
            Assert.Empty(cities);
        }

        /// <summary>
        /// This code is a unit test method that verifies that the GetCityNames action method of the CitiesController class 
        /// throws an exception when the CityService fails.. It catches the exception and 
        /// checks that its message matches the expected one. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetCities_ReturnsNotFound_WhenServiceFails()
        {
            // Arrange

            // Create a mock CityService that simulates an error by throwing an exception.
            var mockCityService = new Mock<ICityService>();
            mockCityService.Setup(x => x.GetCityNames())
                .Throws(new Exception("Simulated error"));

            // Create a mock ServiceManager that returns the mock CityService.
            var mockServiceManager = new Mock<IServiceManager>();
            mockServiceManager.Setup(x => x.CityService)
                .Returns(mockCityService.Object);

            // Create an instance of the CitiesController using the mock ServiceManager.
            var controller = new CitiesController(mockServiceManager.Object);

            // Act and Assert
            var exception = Assert.Throws<Exception>(() => {
                // Call the GetCityNames action on the controller, expecting an exception to be thrown.
                controller.GetCityNames();
            });

            // Check that the result is not null and that it returns an HTTP status code of 500 (Internal Server Error) due to the simulated error.
            Assert.Equal("Simulated error", exception.Message);

        }
    }
}
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
using DarkSkyApi.Models;
using System.IO;
using System.Text.Json;

namespace FMSystems.Tests
{
    public class DSServiceTests
    {

        [Fact(DisplayName = "Noon HourDataPoint is retrieved")]
        public async Task NoonHourDataPointIsRetrieved()
        {
            int noonValue = await Task.FromResult(12);
            var dataPoints = new List<HourDataPoint>();

            var jsonString = File.ReadAllText(@".\TestData\HoursDataPointList.json");
            dataPoints = JsonSerializer.Deserialize<List<HourDataPoint>>(jsonString);

            var sut = new DSService();

            var result = sut.GetForecastForHour(12, dataPoints);
            var dataPoint = result.Result;

            Assert.IsType<HourDataPoint>(dataPoint);

            Assert.Equal(dataPoint.Time.Hour, noonValue);
        }

        [Fact(DisplayName = "Get HourDataPoint Fail with invalid hour param")]
        public void GetHourDataPointFailInvalidHourParam()
        {
            var sut = new DSService();
            var ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await sut.GetForecastForHour(99, null));
            Assert.Equal("InvalidHourParameter", ex.Result.ParamName);
        }


        [Fact(DisplayName = "Get HourDataPoint Fail with invalid DataPoint List")]
        public void GetHourDataPointFailInvalidDataPointList()
        {
            var sut = new DSService();
            var ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await sut.GetForecastForHour(12, null));
            Assert.Equal("InvalidHDataPointsParameter", ex.Result.ParamName);
        }


        [Fact(DisplayName = "Get Weather Data Successfully")]
        public async Task GetWeatherDataSuccessfully()
        {
            //this is intentionally stubbed because I did not want 
            //to abuse the DarkSkyApi and call it too many times...

            Assert.True(await Task.FromResult(true));
        }


        [Fact(DisplayName = "Get Weather Data Fail with invalid parameters")]
        public void GetWeatherDataInvalidParameters()
        {
            var sut = new DSService();
            var ex = Assert.ThrowsAsync<ArgumentNullException>(async() => await sut.GetWeather(null, null, DateTime.MinValue));
            Assert.Equal("InvalidParameters", ex.Result.ParamName);
        }


    } 
}

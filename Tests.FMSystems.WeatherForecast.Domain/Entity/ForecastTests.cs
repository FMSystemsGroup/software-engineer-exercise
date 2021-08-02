using FMSystems.WeatherForecast.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests.FMSystems.WeatherForecast.Infrastructure
{
    public class ForecastRepositoryTest
    {
        #region DateTimeLocal
        [Theory]
        [InlineData(12, -2)]
        [InlineData(12, -5)]
        [InlineData(12, -9)]
        [InlineData(0, 0)]
        [InlineData(0, 9)]
        [InlineData(9, 0)]
        public void DateTimeLocal_Successful(int hour, int offset)
        {
            //Arrange
            var utcTime = new DateTimeOffset(2018, 07, 04, hour, 00, 00, new TimeSpan(0, 0, 0));
            var expectedLocalTime = new DateTimeOffset(2018, 07, 04, hour+offset, 00, 00, new TimeSpan(offset, 0, 0));

            //Act
            var obj = new Forecast();
            obj.DateTimeUTC = utcTime;
            obj.Offset = offset;

            //Assert
            Assert.Equal(expectedLocalTime, obj.DateTimeLocal);
        }
        #endregion

        #region TemperatureC
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        public void Temperature_Successful(double f)
        {
            //Arrange
            double expectedC = (f - 32) * 5 / 9;

            //Act
            var obj = new Forecast();
            obj.TemperatureF = f;

            //Assert
            Assert.Equal(expectedC, obj.TemperatureC);
        }
        #endregion
    }
}
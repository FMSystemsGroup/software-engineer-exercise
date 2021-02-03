using System;
using Xunit;
using WeatherFetchAPI.Dependencies;
using OpenCage.Geocode;

namespace UnitTests
{
	public class WeatherTests
	{
		[Fact]
		public void GetOffsetReturnsCorrectDSTValue()
		{
			//Arrange
			var location = new Location()
			{
				Annotations = new Annotations()
				{
					Timezone = new Timezone()
					{
						Name = "America/Detroit"
					}
				}
			};
			//date within DST
			var time = new DateTime(2018, 7, 4, 12, 0, 0);

			//Act
			var helper = new WeatherHelper();
			var offsetTime = helper.GetUtcVersionOfDate(location.Annotations.Timezone.Name, time);

			//Assert
			Assert.Equal(16, offsetTime.Hour);

		}

		[Fact]
		public void GetOffsetReturnsCorrectStandardValue()
		{
			//Arrange
			var location = new Location()
			{
				Annotations = new Annotations()
				{
					Timezone = new Timezone()
					{
						Name = "America/Detroit"
					}
				}
			};
			//date outside of DST
			var time = new DateTime(2018, 2, 4, 12, 0, 0);

			//Act
			var helper = new WeatherHelper();
			var offsetTime = helper.GetUtcVersionOfDate(location.Annotations.Timezone.Name, time);

			//Assert
			Assert.Equal(17, offsetTime.Hour);

		}

		[Fact]
		public void GetOffsetReturnsCorrectNonDSTValue()
		{
			//Arrange
			var location = new Location()
			{
				Annotations = new Annotations()
				{
					Timezone = new Timezone()
					{
						Name = "America/Phoenix" // no DST in Arizona
					}
				}
			};
			var time = new DateTime(2018, 7, 4, 12, 0, 0);

			//Act
			var helper = new WeatherHelper();
			var offsetTime = helper.GetUtcVersionOfDate(location.Annotations.Timezone.Name, time);

			//Assert
			Assert.Equal(19, offsetTime.Hour);

		}

		[Fact]
		public void GetUnixTimeReturnsCorrectTimeStamp()
		{
			//Arrange
			var time = new DateTime(2018, 7, 4, 19, 0, 0, DateTimeKind.Utc);
			long timeToCheck = 1530730800;

			//Act
			var helper = new WeatherHelper();
			var timeStamp = helper.GetUnixTimeStampForDate(time);

			//Assert
			Assert.Equal(timeToCheck, timeStamp);

		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FMSystems.Services.Interfaces;
using DarkSkyApi;
using DarkSkyApi.Models;
using FMSystems.Shared.DTO;
using Serilog;
using System.Threading.Tasks;

namespace FMSystems.Services
{
    public class DSService : IWeatherService
    {
        public DSService()
        {
            
        }

        /// <summary>
        /// Accesses the DarkSkyApi for a city and date to retrieve the weather in the past
        /// </summary>
        /// <param name="key">DarkSkyApi Key</param>
        /// <param name="city">City you are interested in </param>
        /// <param name="date">the desired date</param>
        /// <returns>a Forecast Object</returns>
        public async Task<Forecast> GetWeather(string key, City city, DateTime date)
        {
            Forecast forecast = null;

            if ((key == null) || (city == null) || (date == null))
                throw new ArgumentNullException("InvalidParameters");


            try
            {

                DateTime utcDate = date.ToUniversalTime();
                var client = new DarkSkyApi.DarkSkyService(key);
                var exclusionList = new List<Exclude> { Exclude.Currently, Exclude.Daily, Exclude.Minutely };
                forecast = await client.GetTimeMachineWeatherAsync(city.Latitude,city.Longitude, utcDate, Unit.US, exclusionList);


            }
            catch (Exception ex)
            {
                Log.Error("Exception in GetWeater: {0}", ex.Message);
                throw ex;
            }

            return forecast;
        }

        /// <summary>
        /// Gets the forecast for the given hour and day and city
        /// </summary>
        /// <param name="desiredHour">What time of day do you want to check (i.e. noon = 12)</param>
        /// <param name="dataPoints">List of HourDataPoints retrieved from the DarkSkyApi</param>
        /// <returns>a  forecast for a specfic hour</returns>
        public async Task<HourDataPoint> GetForecastForHour(int desiredHour, List<HourDataPoint> dataPoints)
        {
            HourDataPoint dataPoint = null;

            if ((desiredHour > 24) || (desiredHour < 1))
                throw new ArgumentNullException("InvalidHourParameter");

            if ((dataPoints == null) || (dataPoints.Count < 1))
                throw new ArgumentNullException("InvalidHDataPointsParameter");

            try
            {
                dataPoint = dataPoints.FirstOrDefault<HourDataPoint>(d => d.Time.Hour == desiredHour);
            }
            catch (Exception ex)
            {
                Log.Error("Exceptiopn in GetForecastForHour: {0}", ex.Message);
            }

            return await Task.FromResult(dataPoint);

        }
    }
}

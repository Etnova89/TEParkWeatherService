using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class MockWeatherSqlDAL : IWeatherSqlDAL
    {
        public List<Weather> GetWeatherByParkCode(string parkCode)
        {
            List<Weather> forecast = new List<Weather>
            {
                new Weather
                {
                    ParkCode = "AAA",
                    FiveDayForecastValue = 1,
                    Low = 0,
                    High = 100,
                    Forecast = "snow"
                },

                new Weather
                {
                    ParkCode = "AAA",
                    FiveDayForecastValue = 2,
                    Low = 50,
                    High = 50,
                    Forecast = "party cloudy"
                },

                new Weather
                {
                    ParkCode = "AAA",
                    FiveDayForecastValue = 3,
                    Low = 20,
                    High = 30,
                    Forecast = "rain"
                },

                new Weather
                {
                    ParkCode = "AAA",
                    FiveDayForecastValue = 4,
                    Low = 0,
                    High = 100,
                    Forecast = "sunny"
                },

                new Weather
                {
                    ParkCode = "AAA",
                    FiveDayForecastValue = 5,
                    Low = 0,
                    High = 100,
                    Forecast = "thunderstorms"
                }
            };

            return forecast;
        }
    }
}

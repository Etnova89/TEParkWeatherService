using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace Capstone.Web.Test.DAL_Tests
{
    [TestClass]
    public class WeatherSqlDALTest
    {
        private TransactionScope tran;
        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=NPGeek;Integrated Security=True";

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                connection.Open();

                cmd = new SqlCommand("INSERT INTO park(parkCode, parkName, state, acreage, elevationInFeet, milesOfTrail, numberOfCampsites, climate, yearFounded, annualVisitorCount,inspirationalQuote, inspirationalQuoteSource, parkDescription, entryFee, numberOfAnimalSpecies) VALUES ('AAA', 'Alpha' ,'Ohio', 100, 1000, 10, 55.5, 'Alpha Climate', 1999, 12000, 'Alpha Quote', 'Alpha Source', 'Alpha Description', 1, 5);", connection);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("INSERT INTO weather(parkCode, fiveDayForecastValue, low, high, forecast) VALUES ('AAA', 1, 1, 1, 'cloudy');", connection);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("INSERT INTO weather(parkCode, fiveDayForecastValue, low, high, forecast) VALUES ('AAA', 2, 1, 1, 'cloudy');", connection);
                cmd.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetWeatherByParkCodeTest()
        {
            WeatherSqlDAL surveySqlDAL = new WeatherSqlDAL(connectionString);

            List<Weather> surveys = surveySqlDAL.GetWeatherByParkCode("AAA");
            Assert.IsNotNull(surveys);
            Assert.AreEqual(1, surveys[0].FiveDayForecastValue);
            Assert.AreEqual(2, surveys[1].FiveDayForecastValue);
        }
    }
}

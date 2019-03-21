using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using System.Data.SqlClient;
using Capstone.Web.DAL.Interface;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using System.Collections.Generic;

namespace Capstone.Web.Test
{
    [TestClass]
    public class SurveySqlDALTest
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

                cmd = new SqlCommand("INSERT INTO survey_result(parkCode, emailAddress, state, activityLevel) VALUES ('AAA', 'TE@TE', 'OH', 'Active')", connection);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("INSERT INTO survey_result(parkCode, emailAddress, state, activityLevel) VALUES ('AAA', 'TE@TE', 'OH', 'Active')", connection);
                cmd.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetParkSurveyResult()
        { 
            SurveySqlDAL surveySqlDAL = new SurveySqlDAL(connectionString);

            List<ViewParksSurveyViewModel> surveys = surveySqlDAL.GetParkSurveyResult();
            Assert.IsNotNull(surveys);
        }

        [TestMethod]
        public void SubmitSurvey()
        {
            SurveySqlDAL surveySqlDAL = new SurveySqlDAL(connectionString);
            Survey survey = new Survey {
                ParkCode = "AAA",
                EmailAddress = "te@techelevator.com",
                State = "Ohio",
                ActivityLevel = "inactive"
            };
            Assert.IsTrue(surveySqlDAL.SubmitSurvey(survey));
        }
    }
}

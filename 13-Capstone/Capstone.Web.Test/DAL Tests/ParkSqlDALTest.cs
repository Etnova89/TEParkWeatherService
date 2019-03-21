using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using System.Data.SqlClient;
using Capstone.Web.DAL.Interface;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using System.Collections.Generic;
using System;

namespace Capstone.Web.Test
{
    [TestClass]
    public class ParkSqlDALTest
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

                cmd = new SqlCommand("INSERT INTO park(parkCode, parkName, state, acreage, elevationInFeet, milesOfTrail, numberOfCampsites, climate, yearFounded, annualVisitorCount,inspirationalQuote, inspirationalQuoteSource, parkDescription, entryFee, numberOfAnimalSpecies) VALUES ('BBB', 'Blpha' ,'Bhio', 100, 1000, 10, 55.5, 'Blpha Climate', 1999, 12000, 'Blpha Quote', 'Blpha Source', 'Blpha Description', 1, 5);", connection);

                cmd.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetAllParksTest()
        {
            ParkSqlDAL parkSqlDAL = new ParkSqlDAL(connectionString);

            List<Park> parks = parkSqlDAL.GetAllParks();
            Assert.IsNotNull(parks);
        }

        [TestMethod]
        public void GetParkByIdTest()
        {
            ParkSqlDAL parkSqlDAL = new ParkSqlDAL(connectionString);

            Park park = parkSqlDAL.GetParkById("AAA");
            Assert.AreEqual("AAA", park.ParkCode);
        }   
    }
}

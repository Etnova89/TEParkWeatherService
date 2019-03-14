using Capstone.Web.DAL.Interface;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL : ISurveySqlDAL
    {
        private string connectionString;
        private string SQL_GetSurverys = @"";
        private string SQL_SubmitSurvey = @"INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @emailAddress, @state, @activityLevel)";

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Survey GetSurvey()
        {
            Survey survey = new Survey();
            return survey;
        }

        public bool SubmitSurvey(Survey survey)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SubmitSurvey, connection);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;

        }
    }
}

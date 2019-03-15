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
        private string SQL_GetParkSurveyResult = @"SELECT COUNT(survey_result.parkCode) as total_surveys, survey_result.parkCode, park.parkName FROM survey_result JOIN park ON survey_result.parkCode = park.parkCode GROUP BY survey_result.parkCode, parkName ORDER BY total_surveys DESC, survey_result.parkCode;";

        private string SQL_SubmitSurvey = @"INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @emailAddress, @state, @activityLevel)";

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ViewParksSurveyViewModel> GetParkSurveyResult()
        {
            List<ViewParksSurveyViewModel> parkSurveyResult = new List<ViewParksSurveyViewModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetParkSurveyResult, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ViewParksSurveyViewModel parkSurvey = new ViewParksSurveyViewModel();
                        Park park = new Park();
                        parkSurvey.NumberOfSurveys = Convert.ToInt32(reader["total_surveys"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.ParkCode = Convert.ToString(reader["parkCode"]);

                        parkSurvey.Park = park;
                        parkSurveyResult.Add(parkSurvey);
                    }
                }
            }
            catch
            {
                throw;
            }

            return parkSurveyResult;
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

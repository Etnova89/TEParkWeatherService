using Capstone.Web.DAL.Interface;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class MockSurveySqlDAL : ISurveySqlDAL
    {
        public List<ViewParksSurveyViewModel> GetParkSurveyResult()
        {
            List<ViewParksSurveyViewModel> viewModelList = new List<ViewParksSurveyViewModel>
            {
                new ViewParksSurveyViewModel
                {
                    Park = new Park
                    {
                        ParkCode = "EEE",
                        ParkName = "Echo",
                    },
                    NumberOfSurveys = 100
                },

                new ViewParksSurveyViewModel
                {
                    Park = new Park
                    {
                        ParkCode = "FFF",
                        ParkName = "Foxtrot",
                    },
                    NumberOfSurveys = 10
                },

                new ViewParksSurveyViewModel
                {
                    Park = new Park
                    {
                        ParkCode = "GGG",
                        ParkName = "Golf",
                    },
                    NumberOfSurveys = 1
                }
            };

            return viewModelList;
        }

        public bool SubmitSurvey(Survey survey)
        {
            return true;
        }
    }
}

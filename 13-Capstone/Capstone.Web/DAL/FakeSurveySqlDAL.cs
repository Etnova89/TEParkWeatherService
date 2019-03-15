using Capstone.Web.DAL.Interface;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class FakeSurveySqlDAL : ISurveySqlDAL
    {
        public Survey GetSurvey()
        {
            throw new NotImplementedException();
        }

        public bool SubmitSurvey(Survey survey)
        {
            throw new NotImplementedException();
        }
    }
}

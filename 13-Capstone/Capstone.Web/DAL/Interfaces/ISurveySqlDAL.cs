using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL.Interface
{
    public interface ISurveySqlDAL
    {
        Survey GetSurvey();
        bool SubmitSurvey(Survey survey);
    }
}

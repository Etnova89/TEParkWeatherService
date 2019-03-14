using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.DAL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveySqlDAL surveySqlDAL;

        public SurveyController(ISurveySqlDAL surveySqlDAL)
        {
            this.surveySqlDAL = surveySqlDAL;
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult ViewParkSurvey()
        {
            return View();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.DAL.Interface;
using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveySqlDAL surveySqlDAL;
        private IParkSqlDAL parkSqlDAL;

        public SurveyController(ISurveySqlDAL surveySqlDAL, IParkSqlDAL parkSqlDAL)
        {
            this.surveySqlDAL = surveySqlDAL;
            this.parkSqlDAL = parkSqlDAL;
        }

        [HttpGet]
        public IActionResult Form()
        {
            FormViewModel model = new FormViewModel(parkSqlDAL.GetAllParks());
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Form(Survey model)
        {

            if (ModelState.IsValid)
            {
                if (surveySqlDAL.SubmitSurvey(model))
                {
                    TempData["SHOW_MESSAGE_KEY"] = true;
                    return RedirectToAction(nameof(ViewParkSurvey));
                }
            }
            return View(model);
        }

        public IActionResult ViewParkSurvey()
        {
            return View();
        }

    }
}
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
        public IActionResult SurveyForm()
        {
            SurveyFormViewModel model = new SurveyFormViewModel();
            model.Parks = model.GetParksSelectList(parkSqlDAL.GetAllParks());

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SurveyForm(SurveyFormViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (surveySqlDAL.SubmitSurvey(model.Survey))
                {
                    TempData["SHOW_MESSAGE_KEY"] = true;
                    return RedirectToAction(nameof(ViewParkSurvey));
                }
            }
            return View(model);
        }

        public IActionResult ViewParkSurvey()
        {
            List<ViewParksSurveyViewModel> model = new List<ViewParksSurveyViewModel>(surveySqlDAL.GetParkSurveyResult());

            return View(model);
        }

    }
}
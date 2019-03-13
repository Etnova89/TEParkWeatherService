using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class ParkController : Controller
    {
        private IParkSqlDAL parkSqlDAL;
        private IWeatherSqlDAL weatherSqlDAL;

        public ParkController(IParkSqlDAL parkSqlDAL, IWeatherSqlDAL weatherSqlDAL)
        {
            this.parkSqlDAL = parkSqlDAL;
            this.weatherSqlDAL = weatherSqlDAL;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            List<Park> result = parkSqlDAL.GetAllParks();
            return View(result);
        }

        public IActionResult Detail(string parkCode)
        {
            ParkDetailViewModel parkDetailViewModel = new ParkDetailViewModel
            {
                SelectedPark = parkSqlDAL.GetParkById(parkCode),
                ParkWeatherForcast = weatherSqlDAL.GetWeatherByParkCode(parkCode)

            };
            return View(parkDetailViewModel);
        }
    }
}
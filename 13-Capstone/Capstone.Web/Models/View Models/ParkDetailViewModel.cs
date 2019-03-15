using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkDetailViewModel
    {
        public Park SelectedPark { get; set; }
        public List<Weather> ParkWeatherForecast { get; set; }
    }
}

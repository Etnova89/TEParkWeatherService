using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }

        [Display(Name = "Park Code")]
        public string ParkCode { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Activity Level")]
        public string ActivityLevel { get; set; }
    }
}

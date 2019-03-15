using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }

        public int ConvertToC(int temperature)
        {
            int convertedTemp = 0;

            convertedTemp = (int)Math.Round((temperature - 32.0) * (5 / 9.0));
            
            return convertedTemp;
        }

        public string GetForecastMessage()
        {
            string message = "";
            
            if (Forecast == "sunny")
            {
                message = "Pack Sun Block";
            }
            else if (Forecast == "snow")
            {
                message = "Pack Snow Shoes";
            }
            else if (Forecast == "rain")
            {
                message = "Pack Rain Gear and Water Proof Shoes";
            }
            else if (Forecast == "thunderstorms")
            {
                message = "Seek Shelder and Avoid Hiking on exposed ridges";
            }

            return message;
        }

        public List<string> GetTemperatureMessages()
        {
            List<string> messages = new List<string>();

            if (High > 75)
            {
                messages.Add("Bring Extra Gallon of Water");
            }
            else if (Low < 20)
            {
                messages.Add("Beware of Low Temperature");
            }
            else if(High - Low > 20)
            {
                messages.Add("Wear breathable layers");
            }

            return messages;
        }
        
    }
}

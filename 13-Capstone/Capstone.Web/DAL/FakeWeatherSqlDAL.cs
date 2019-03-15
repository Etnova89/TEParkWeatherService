using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class FakeWeatherSqlDAL : IWeatherSqlDAL
    {
        public List<Weather> GetWeatherByParkCode(string parkCode)
        {
            throw new NotImplementedException();
        }
    }
}

using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class FakeParkSqlDAL : IParkSqlDAL
    {
        public List<Park> GetAllParks()
        {
            List<Park> parkList = new List<Park>();
            return parkList;
        }

        public Park GetParkById(string id)
        {
            Park park = new Park();
            return park;
        }
    }
}

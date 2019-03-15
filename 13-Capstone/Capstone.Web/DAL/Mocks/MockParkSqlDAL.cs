using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class MockParkSqlDAL : IParkSqlDAL
    {
        public List<Park> GetAllParks()
        {
            List<Park> parkList = new List<Park>
            {
                new Park
                {
                    ParkCode = "AAA",
                    ParkName = "Alpha",
                    State = "Ohio",
                    Acreage = 100,
                    ElevationInFeet = 1000,
                    NumberOfCampsites = 10,
                    MilesOfTrail = 55.5,
                    Climate = "Alpha Climate",
                    YearFounded = 1999,
                    AnnualVisitorCount = 12000,
                    InspirationalQuote = "Alpha Quote",
                    InspirationalQuoteSource = "Alpha Source",
                    ParkDescription = "Alpha Description",
                    EntryFee = 1,
                    NumberOfAnimalSpecies = 5
                },

                new Park
                {
                    ParkCode = "BBB",
                    ParkName = "Bravo",
                    State = "Michigan",
                    Acreage = 200,
                    ElevationInFeet = 2000,
                    NumberOfCampsites = 20,
                    MilesOfTrail = 255.5,
                    Climate = "Bravo Climate",
                    YearFounded = 2999,
                    AnnualVisitorCount = 22000,
                    InspirationalQuote = "Bravo Quote",
                    InspirationalQuoteSource = "Bravo Source",
                    ParkDescription = "Bravo Description",
                    EntryFee = 21,
                    NumberOfAnimalSpecies = 25
                },

                new Park
                {
                    ParkCode = "CCC",
                    ParkName = "Charlie",
                    State = "Indiana",
                    Acreage = 3100,
                    ElevationInFeet = 31000,
                    NumberOfCampsites = 310,
                    MilesOfTrail = 355.5,
                    Climate = "Charlie Climate",
                    YearFounded = 3999,
                    AnnualVisitorCount = 32000,
                    InspirationalQuote = "Charlie Quote",
                    InspirationalQuoteSource = "Charlie Source",
                    ParkDescription = "Charlie Description",
                    EntryFee = 31,
                    NumberOfAnimalSpecies = 35
                }
            };

            return parkList;
        }

        public Park GetParkById(string parkCode)
        {
            return new Park
            {
                ParkCode = "DDD",
                ParkName = "Delta",
                State = "Kentucky",
                Acreage = 4100,
                ElevationInFeet = 41000,
                NumberOfCampsites = 410,
                MilesOfTrail = 455.5,
                Climate = "Delta Climate",
                YearFounded = 4999,
                AnnualVisitorCount = 42000,
                InspirationalQuote = "Delta Quote",
                InspirationalQuoteSource = "Delta Source",
                ParkDescription = "Delta Description",
                EntryFee = 41,
                NumberOfAnimalSpecies = 45
            };
        }
    }
}

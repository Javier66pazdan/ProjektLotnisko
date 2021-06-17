using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektLotnisko.DbClasses
{
    public class Airline
    {
        public int AirlineId { get; set; }
        public string Name { get; set; }
        public string CountryAirline { get; set; }
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektLotnisko.DbClasses
{
    public class Airport
    {
        public int AirportId { get; set; }
        public string City { get; set; }
        public string CountryAirport { get; set; }
        public string AdressStreetAirport { get; set; }
        public string AdressNumberAirport { get; set; }
    }
}

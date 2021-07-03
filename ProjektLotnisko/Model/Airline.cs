using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektLotnisko.DbClasses
{
    public class Airline
    {
        public int AirlineId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        public int YearFounded { get; set; }
        [StringLength(100)]
        public string CountryAirline { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
    }
}

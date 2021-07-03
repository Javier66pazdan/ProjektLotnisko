using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektLotnisko.DbClasses
{
    public class Airport
    {
        public int AirportId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(100)]
        public string Province { get; set; }
        [StringLength(100)]
        public string CountryAirport { get; set; }
    }
}

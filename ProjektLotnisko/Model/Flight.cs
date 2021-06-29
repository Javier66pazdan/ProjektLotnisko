using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektLotnisko.DbClasses
{
    public class Flight
    {
        public int flightId { get; set; }
        public Airline Airline { get; set; }
        public Airport AirportFromLocation { get; set; }
        public Airport AirportToLocation { get; set; }
        public DateTime TimeDeparture  { get; set; }
        public DateTime TimeArrival { get; set; }
        public string FlightCode { get; set; }
        public int SeatsNumber { get; set; }
        public int TicketPrice { get; set; }
    }
}

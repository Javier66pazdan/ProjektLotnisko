using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektLotnisko.DbClasses
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public User User { get; set; }
        public Flight Flight { get; set; }
        public string State { get; set; }
        public string ClassName { get; set; }
        public int Price { get; set; }
    }
}

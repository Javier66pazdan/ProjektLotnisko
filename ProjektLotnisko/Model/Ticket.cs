using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [StringLength(100)]
        public string State { get; set; }
    }
}

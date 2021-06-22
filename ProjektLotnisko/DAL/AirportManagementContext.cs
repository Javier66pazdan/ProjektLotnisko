using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProjektLotnisko.DbClasses;

namespace ProjektLotnisko.DAL
{
    public class AirportManagementContext : DbContext
    {
        public AirportManagementContext() : base("AirportManagementContext")
        {
            //wylaczenie initializera
            Database.SetInitializer<AirportManagementContext>(null);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}

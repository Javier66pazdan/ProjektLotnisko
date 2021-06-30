using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProjektLotnisko.DbClasses;
using System.Windows;

namespace ProjektLotnisko.DAL
{
    public class AirportInitializer : DropCreateDatabaseIfModelChanges<AirportManagementContext>
    {
        protected override void Seed(AirportManagementContext context)
        {
            var users = new List<User>
            {
                new User{Email="admin@gmail.com",Password="admin",FirstName="admin",LastName="admin",
                    SignUpDate=new DateTime(2000,5,1,8,30,52), AdressStreet="adminowa",AdressNumber="123"
                    ,Country="Poland",City="Adminowo", AccountType= "admin"},
                new User{Email="tester",Password="admin",FirstName="marek",LastName="tester",
                    SignUpDate=new DateTime(2003,5,1,8,30,52), AdressStreet="testowa",AdressNumber="42"
                    ,Country="Poland",City="Rzeszów", AccountType= "normal"}
            };
            users.ForEach(s => context.Users.Add(s));
            
            var airports = new List<Airport>
            {
                new Airport{Name="Biała Podlaska",Code="EPBP",City="Biała Podlaska",
                    Province="LB",CountryAirport="Poland"},
                new Airport{Name="Elbląg",Code="EPEL",City="Elbląg",
                    Province="WM",CountryAirport="Poland"},
                new Airport{Name="Rzeszów-Jasionka",Code="EPRZ",City="Rzeszów",
                    Province="PK",CountryAirport="Poland"}
            };
            airports.ForEach(s => context.Airports.Add(s));

            var airlines = new List<Airline>
            {
                new Airline{Name="LOT Polish Airlines",Code="LOT",YearFounded=1929,
                    CountryAirline="Poland"},
                new Airline{Name="Buzz",Code="RYS",YearFounded=2018,
                    CountryAirline="Poland",Description="previously Ryanair Sun"},
                new Airline{Name="British Airways",Code="BAW/SHT",YearFounded=1974,
                    CountryAirline="United Kingdom"},
            };
            airlines.ForEach(s => context.Airlines.Add(s));
            context.SaveChanges();
        }
    }
}

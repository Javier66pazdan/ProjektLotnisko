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
                new User{Email="a@wp.pl",Password=PasswordHasher.Hash("123"),FirstName="Marek",LastName="Wojecki",
                    SignUpDate=new DateTime(2001,2,4,8,12,24), AdressStreet="Mickiewicza",AdressNumber="12"
                    ,Country="Poland",City="Rzeszów", AccountType= "normal"},
                new User{Email="b@wp.pl",Password=PasswordHasher.Hash("123"),FirstName="Wojciech",LastName="Torecki",
                    SignUpDate=new DateTime(2006,1,12,20,44,30), AdressStreet="Sikorskiego",AdressNumber="133/14"
                    ,Country="Poland",City="Rzeszów", AccountType= "normal"},
                new User{Email="c@wp.pl",Password=PasswordHasher.Hash("123"),FirstName="John",LastName="Smith",
                    SignUpDate=new DateTime(2012,10,22,10,1,30), AdressStreet="15th",AdressNumber="16"
                    ,Country="England",City="London", AccountType= "normal"},
                new User{Email="d@wp.pl",Password=PasswordHasher.Hash("123"),FirstName="Vladimir",LastName="Putin",
                    SignUpDate=new DateTime(2016,1,22,10,1,30), AdressStreet="Tverskaya",AdressNumber="1"
                    ,Country="Russia",City="Moscow", AccountType= "normal"},
            };
            users.ForEach(s => context.Users.Add(s));
            
            var airports = new List<Airport>
            {
                new Airport{Name="Biała Podlaska",Code="EPBP",City="Biała Podlaska",
                    Province="LB",CountryAirport="Poland"},
                new Airport{Name="Elbląg",Code="EPEL",City="Elbląg",
                    Province="WM",CountryAirport="Poland"},
                new Airport{Name="Rzeszów-Jasionka",Code="EPRZ",City="Rzeszów",
                    Province="PK",CountryAirport="Poland"},
                new Airport{Name="London City Airport",Code="EGLC",City="Newham",
                    Province="Greater London",CountryAirport="United Kingdom"},
                new Airport{Name="Gatwick Airport",Code="EGKK",City="Crawley",
                    Province="West Sussex",CountryAirport="United Kingdom"},
                new Airport{Name="Moscow Domodedevo Airport",Code="UUDD",City="Moscow",
                    Province="Central Federal Districk",CountryAirport="Russia"},
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
                new Airline{Name="NordStar",Code="TYA",YearFounded=2009,
                    CountryAirline="Russia"},
                new Airline{Name="Alitalia",Code="AZA",YearFounded=1946,
                    CountryAirline="Italy"},
            };
            airlines.ForEach(s => context.Airlines.Add(s));

            var flights = new List<Flight>
            {
                new Flight{Airline=airlines[0],AirportFromLocation=airports[0],AirportToLocation=airports[1],
                    TimeDeparture=new DateTime(2021,7,12,8,30,00), TimeArrival=new DateTime(2021,7,12,10,30,00),
                    FlightCode = "BA2490", SeatsNumber = 40, TicketPrice = 600 },
                new Flight{Airline=airlines[1],AirportFromLocation=airports[1],AirportToLocation=airports[2],
                    TimeDeparture=new DateTime(2021,7,21,12,30,00), TimeArrival=new DateTime(2021,7,21,14,30,00),
                    FlightCode = "AS2142", SeatsNumber = 70, TicketPrice = 400 },
                new Flight{Airline=airlines[0],AirportFromLocation=airports[2],AirportToLocation=airports[0],
                    TimeDeparture=new DateTime(2021,8,3,14,00,00), TimeArrival=new DateTime(2021,8,3,16,30,00),
                    FlightCode = "LO0213", SeatsNumber = 100, TicketPrice = 400 },
                new Flight{Airline=airlines[2],AirportFromLocation=airports[2],AirportToLocation=airports[3],
                    TimeDeparture=new DateTime(2021,8,10,14,00,00), TimeArrival=new DateTime(2021,8,10,20,15,00),
                    FlightCode = "BW1023", SeatsNumber = 50, TicketPrice = 1000 },
                new Flight{Airline=airlines[3],AirportFromLocation=airports[5],AirportToLocation=airports[2],
                    TimeDeparture=new DateTime(2021,7,15,4,00,00), TimeArrival=new DateTime(2021,7,15,12,00,00),
                    FlightCode = "NS9921", SeatsNumber = 100, TicketPrice = 1500 },
            };
            flights.ForEach(s => context.Flights.Add(s));

            var tickets = new List<Ticket>
            {
                new Ticket{User=users[1],Flight=flights[0],State="Zarezerwowany"},
                new Ticket{User=users[2],Flight=flights[1],State="Anulowany"},
                new Ticket{User=users[3],Flight=flights[2],State="Opłacony"},
                new Ticket{User=users[4],Flight=flights[3],State="Opłacony"},
                new Ticket{User=users[1],Flight=flights[4],State="Zarezerwowany"},
            };
            tickets.ForEach(s => context.Tickets.Add(s));

            context.SaveChanges();
        }
    }
}

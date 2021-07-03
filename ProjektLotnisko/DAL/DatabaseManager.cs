using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjektLotnisko.DbClasses;
using System.Data.Entity.Migrations;

namespace ProjektLotnisko.DAL
{
    public class DatabaseManager
    {
        AirportManagementContext db;
        public DatabaseManager()
        {
            db = new AirportManagementContext();
        }
        public List<User> usersList()
        {
            var users = (from p in db.Users select p).ToList();
            return users;
        }
        public void addUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public void removeUser(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }
        public void editUser(User user)
        {
            db.Users.AddOrUpdate(user);
            db.SaveChanges();
        }
        public bool isEmailAvailable (string email)
        {
            if (db.Users.Any(o => o.Email == email))
            { return false; }
            return true;
        }
        public List<Airline> airlineList()
        {
            var airlines = (from p in db.Airlines select p).ToList();
            return airlines;
        }
        public void addAirline(Airline airline)
        {
            db.Airlines.Add(airline);
            db.SaveChanges();
        }
        public void removeAirline(Airline airline)
        {
            db.Airlines.Remove(airline);
            db.SaveChanges();
        }
        public void editAirline (Airline airline)
        {
            db.Airlines.AddOrUpdate(airline);
            db.SaveChanges();
        }
        public List<Flight> flightsList()
        {
            var flights = (from p in db.Flights select p).ToList();
            return flights;
        }
        public void addFlight(Flight flight)
        {
            db.Flights.Add(flight);
            db.SaveChanges();
        }
        public void removeFlight(Flight flight)
        {
            db.Flights.Remove(flight);
            db.SaveChanges();
        }
        public void editFlight(Flight flight)
        {
            db.Flights.AddOrUpdate(flight);
            db.SaveChanges();
        }
        public List<Airport> airportList()
        {
            var airports = (from p in db.Airports select p).ToList();
            return airports;
        }
        public void addAirport(Airport airport)
        {
            db.Airports.Add(airport);
            db.SaveChanges();
        }
        public void removeAirport(Airport airport)
        {
            db.Airports.Remove(airport);
            db.SaveChanges();
        }
        public void editAirport(Airport airport)
        {
            db.Airports.AddOrUpdate(airport);
            db.SaveChanges();
        }
        public List<Ticket> ticketList()
        {
            var tickets = (from p in db.Tickets select p).ToList();
            return tickets;
        }
        public void addTicket(Ticket ticket)
        {
            db.Tickets.Add(ticket);
            db.SaveChanges();
        }
        public void removeTicket(Ticket ticket)
        {
            db.Tickets.Remove(ticket);
            db.SaveChanges();
        }
        public void editTicket(Ticket ticket)
        {
            db.Tickets.AddOrUpdate(ticket);
            db.SaveChanges();
        }
        public List<Ticket> ticketForUserList(User user)
        {
            var tickets = (from p in db.Tickets where p.User.UserId == user.UserId select p).ToList();
            return tickets;
        }

        public User findUserWithEmail(string email)
        {
            User emailUser = db.Users.Single(o => o.Email == email);
            return emailUser;
        }

        public bool isUserInDatabase (string email)
        {
            return db.Users.Any(o => o.Email == email);
        }
        public User findUserWithId(int id)
        {
            User emailUser = db.Users.Single(o => o.UserId == id);
            return emailUser;
        }
        public void saveChanges()
        {
            db.SaveChanges();
        }
        public bool isCodeFlightAvailable(string code)
        {
            if (db.Flights.Any(o => o.FlightCode == code))
            { return false; }
            return true;
        }
    }
}

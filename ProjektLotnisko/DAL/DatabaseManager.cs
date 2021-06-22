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
                return false;
            else return true;
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

    }
}

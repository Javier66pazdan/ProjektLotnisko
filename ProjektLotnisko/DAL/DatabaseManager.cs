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
    }
}

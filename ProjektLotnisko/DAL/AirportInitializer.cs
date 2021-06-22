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
                new User{Email="admin",Password="admin",FirstName="admin",LastName="admin",
                    SignUpDate=new DateTime(2000,5,1,8,30,52), AdressStreet="adminowa",AdressNumber="123"
                    ,Country="Poland" }
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
            
        }
    }
}

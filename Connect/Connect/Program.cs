using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connect.EF;

namespace Connect
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new DbConnect())
            {
                db.Users.Add(new User
                {
                    User_Id = db.Users.Count() + 1,
                    Username = "Slayer",
                    User_role = "Programmer"
                });
                db.SaveChanges();

                foreach (var user in db.Users)
                {
                    Console.WriteLine($"User ID: {user.User_Id}\tUsername: {user.Username}\tUser role: {user.User_role}");
                }
            }

            using (var db = new DbConnect())
            {
                var user = db.Users;
                foreach (var x in user)
                {
                    Console.WriteLine($"User Id: {x.User_Id}\tName: {x.Username}\tRole: {x.User_role}");
                }
            }
        }
    }
}

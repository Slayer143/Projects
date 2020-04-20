using CybersportApp.Core.CybersportEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportApp.Core
{
    public static class CybersportCore
    {
        public static ObservableCollection<Countries> CountriesCollection { get; set; }

        public static ObservableCollection<Roles> RolesCollection { get; set; }

        public static ObservableCollection<Teams> TeamsCollection { get; set; }

    public static void AddUser(Users user)
        {
            using (var context = new CybersportConnection())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static bool CheckLogin(string login)
        {
            if (login == "Try another login"
                || login == string.Empty
                || login.Contains(' '))
                return false;

            using (var context = new CybersportConnection())
            {
                var user = context.Users.FirstOrDefault(x => x.Login == login);

                return user == null
                    ? true
                    : false;
            }
        }

        public static Users CheckUser(string login, string password)
        {
            var user = new Users();

            using (var context = new CybersportConnection())
            {
                return context.Users
                   .FirstOrDefault(x =>
                   x.Login == login
                   && x.Password == password);
            }
        }

        public static ObservableCollection<string> GetRoles()
        {
            var roles = new ObservableCollection<string>();
            RolesCollection = new ObservableCollection<Roles>();

            using (var context = new CybersportConnection())
            {
                foreach (var role in context.Roles)
                {
                    RolesCollection.Add(role);

                    if (role.RoleId != 1)
                        roles.Add(role.Name);
                }
            }

            return roles;
        }

        public static ObservableCollection<string> GetCountries()
        {
            var countries = new ObservableCollection<string>();
            CountriesCollection = new ObservableCollection<Countries>();

            using (var context = new CybersportConnection())
            {
                foreach (var country in context.Countries)
                {
                    CountriesCollection.Add(country);

                    if (country.CountryId != 1)
                        countries.Add(country.Name);
                }
            }

            return countries;
        }

        public static string GetTeam(int teamId)
        {
            using (var context = new CybersportConnection())
            {
                return context.Teams.Find(teamId).Name;
            }
        }
    }
}

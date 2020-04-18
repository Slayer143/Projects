using CybersportApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportApplication.Core
{
    public static class CybersportCore
    {
        public static Users CurrentUser { get; set; }

        public static ObservableCollection<Countries> CountriesCollection { get; set; }

        public static ObservableCollection<Roles> RolesCollection { get; set; }

        public static void GetRoles()
        {
            RolesCollection = new ObservableCollection<Roles>();

            using (var context = new CybersportRepository())
            {
                var roles = context.Roles.ToList();

                foreach (var item in roles)
                {
                    RolesCollection.Add(item);
                }
            }
        }

        public static ObservableCollection<Countries> GetCountries()
        {
            CountriesCollection = new ObservableCollection<Countries>();

            using (var context = new CybersportRepository())
            {
                foreach (var country in context.Countries)
                {
                    CountriesCollection.Add(country);
                }
            }

            return CountriesCollection;
        }

        public static bool CheckAuthUserData(string login, string password)
        {
            using (var context = new CybersportRepository())
            {
                CurrentUser = context
                    .Users
                    .Where(x => x.Login == login
                        && x.Password == password)
                    .FirstOrDefault();
            }

            if (CurrentUser != null)
                return true;

            return false;
        }
    }
}

using CybersportApp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportApp.Pages
{
    public class ProfileMenuVM : INotifyPropertyChanged
    {
        private string _login { get; set; }

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        private string _fullName { get; set; }

        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        private string _birthDate { get; set; }

        public string BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        private string _country { get; set; }

        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged("Country");
            }
        }

        private string _team { get; set; }

        public string Team
        {
            get { return _team; }
            set
            {
                _team = value;
                OnPropertyChanged("Team");
            }
        }

        private byte[] _photo { get; set; }

        public byte[] Photo
        {
            get { return _photo; }
            set
            {
                _photo = value;
                OnPropertyChanged("Photo");
            }
        }

        public ProfileMenuVM()
        {
            Login = CybersportAppNavigation.CurrentUser.Login;
            FullName = $"{CybersportAppNavigation.CurrentUser.LastName} " +
                $"{CybersportAppNavigation.CurrentUser.Name} " +
                $"{CybersportAppNavigation.CurrentUser.SecondName}";
            BirthDate = CybersportAppNavigation.CurrentUser.BirthDate.ToString().Substring(0, 10);

            Country = GetCountry();
            Team = CybersportCore.GetTeam(CybersportAppNavigation.CurrentUser.TeamId);
            Photo = CybersportAppNavigation.CurrentUser.Photo;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }

        private string GetCountry()
        {
            if (CybersportCore.CountriesCollection == null)
                CybersportCore.GetCountries();
            
            return CybersportCore
                    .CountriesCollection
                    .Where(x =>
                    x.CountryId == CybersportAppNavigation.CurrentUser.CountryId)
                    .FirstOrDefault()
                    .Name;
        }
    }
}

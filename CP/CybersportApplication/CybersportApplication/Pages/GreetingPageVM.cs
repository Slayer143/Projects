using CybersportApplication.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportApplication.Pages
{
    class GreetingPageVM : INotifyPropertyChanged
    {
        private RelayCommand _goRegister;
        public RelayCommand GoRegister
        {
            get
            {
                return _goRegister ??
                    (_goRegister = new RelayCommand(x =>
                    {
                        CybersportNavigation.Service.Navigate(new RegistrationPage());
                    }));
            }
        }

        private RelayCommand _goAuth;
        public RelayCommand GoAuth
        {
            get
            {
                return _goAuth ??
                    (_goAuth = new RelayCommand(x =>
                    {
                        //CybersportNavigation.Service.Navigate(new AuthorizationPage());
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}

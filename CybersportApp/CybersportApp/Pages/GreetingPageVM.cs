using System.ComponentModel;

namespace CybersportApp.Pages
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
                        CybersportAppNavigation.Service.Navigate(new RegistrationPage());
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
                        CybersportAppNavigation.Service.Navigate(new AuthorizationPage());
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

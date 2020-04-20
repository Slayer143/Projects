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
                        if (CybersportAppNavigation.CurrentRegistrationPage != null)
                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentRegistrationPage);
                        else
                        {
                            CybersportAppNavigation.CurrentRegistrationPage = new RegistrationPage();
                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentRegistrationPage);
                        }
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
                        if (CybersportAppNavigation.CurrentAuthorizationPage != null)
                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentAuthorizationPage);
                        else
                        {
                            CybersportAppNavigation.CurrentRegistrationPage = new AuthorizationPage();
                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentRegistrationPage);
                        }
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

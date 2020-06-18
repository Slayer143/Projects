using CybersportApp.Pages;
using System.ComponentModel;

namespace PavilionsApp.Pages
{
    public class BeginnerPageVM : INotifyPropertyChanged
    {
        private RelayCommand _register { get; set; }

        public RelayCommand Register
        {
            get
            {
                return _register ??
                    (_register = new RelayCommand(x =>
                    {
                        PavilionsNavigation.Service.Navigate(new RegisterPage());
                    }));
            }
        }

        private RelayCommand _auth { get; set; }

        public RelayCommand Auth
        {
            get
            {
                return _auth ??
                    (_auth = new RelayCommand(x =>
                    {
                        PavilionsNavigation.Service.Navigate(new AuthPage());
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

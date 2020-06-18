using CybersportApp.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionsApp.Pages
{
    public class ManagerCPageVM : INotifyPropertyChanged
    {
        private RelayCommand _exit { get; set; }

        public RelayCommand Exit
        {
            get
            {
                return _exit ??
                    (_exit = new RelayCommand(x =>
                    {
                        PavilionsNavigation.CurrentUser = null;
                        PavilionsNavigation.Service.Navigate(new BeginnerPage());
                    }));
            }
        }

        private RelayCommand _shoppingCenters { get; set; }

        public RelayCommand ShoppingCenters
        {
            get
            {
                return _shoppingCenters ??
                    (_shoppingCenters = new RelayCommand(x =>
                    {
                        PavilionsNavigation.Service.Navigate(new ShoppingCentersPage());
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

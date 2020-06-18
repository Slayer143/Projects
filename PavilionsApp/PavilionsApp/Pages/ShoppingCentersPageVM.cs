using CybersportApp.Pages;
using PavilionsApp.Core;
using PavilionsApp.Core.EntitiesForList;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PavilionsApp.Pages
{
    public class ShoppingCentersPageVM : INotifyPropertyChanged
    {
        private string _city { get; set; }

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }

        private ObservableCollection<string> _cities { get; set; }

        public ObservableCollection<string> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                OnPropertyChanged("Cities");
            }
        }

        private string _status { get; set; }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        private ObservableCollection<string> _statuses { get; set; }

        public ObservableCollection<string> Statuses
        {
            get { return _statuses; }
            set
            {
                _statuses = value;
                OnPropertyChanged("Statuses");
            }
        }

        private ObservableCollection<ShoppingCentersForList> _shoppingCentersList { get; set; }

        public ObservableCollection<ShoppingCentersForList> ShoppingCentersList
        {
            get { return _shoppingCentersList; }
            set
            {
                _shoppingCentersList = value;
                OnPropertyChanged("ShoppingCentersList");
            }
        }

        private ShoppingCentersForList  _selectedShoppingCenter { get; set; }

        public ShoppingCentersForList SelectedShoppingCenter
        {
            get { return _selectedShoppingCenter; }
            set
            {
                _selectedShoppingCenter = value;
                OnPropertyChanged("SelectedShoppingCenter");
            }
        }

        private RelayCommand _back { get; set; }

        public RelayCommand Back
        {
            get
            {
                return _back ??
                    (_back = new RelayCommand(x =>
                    {
                        if (PavilionsNavigation.Service.CanGoBack)
                            PavilionsNavigation.Service.GoBack();
                    }));
            }
        }

        private RelayCommand _goToEditor { get; set; }

        public RelayCommand GoToEditor
        {
            get
            {
                return _goToEditor ??
                    (_goToEditor = new RelayCommand(x =>
                    {
                        if (SelectedShoppingCenter != null)
                        {
                            PavilionsNavigation.ShoppingCenter = SelectedShoppingCenter;
                            PavilionsNavigation.CenterCode = PavilionsCore.GetShoppingCenterId(SelectedShoppingCenter.Name);
                            PavilionsNavigation.Service.Navigate(new ShoppingCentersEditorPage());
                        }
                    }));
            }
        }

        private RelayCommand _clearFilters { get; set; }

        public RelayCommand ClearFilters
        {
            get
            {
                return _clearFilters ??
                    (_clearFilters = new RelayCommand(x =>
                    {
                        City = null;
                        Status = null;

                        ShoppingCentersList = PavilionsCore.ShoppingCenters;
                    }));
            }
        }

        private RelayCommand _useFilters { get; set; }

        public RelayCommand UseFilters
        {
            get
            {
                return _useFilters ??
                    (_useFilters = new RelayCommand(x =>
                    {
                        if (City == null
                            && Status == null)
                            ShoppingCentersList = PavilionsCore.ShoppingCenters;

                        if (City == null
                            && Status != null)
                            ShoppingCentersList = PavilionsCore.FilterBy(Status, 1);

                        if (City != null
                            && Status == null)
                            ShoppingCentersList = PavilionsCore.FilterBy(City);

                        if (City != null
                            && Status != null)
                            ShoppingCentersList = PavilionsCore.FilterBy(Status, City);
                    }));
            }
        }

        private RelayCommand _addShoppingCenter { get; set; }

        public RelayCommand AddShoppingCenter
        {
            get
            {
                return _addShoppingCenter ??
                    (_addShoppingCenter = new RelayCommand(x =>
                    {
                        PavilionsNavigation.Service.Navigate(new ShoppingCentersAddingPage());
                    }));
            }
        }

        public ShoppingCentersPageVM()
        {
            PavilionsCore.GetCentersForList();
            ShoppingCentersList = PavilionsCore.ShoppingCenters;

            Statuses = PavilionsCore.GetStatusesNames();
            Cities = PavilionsCore.GetCitiesNames();
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

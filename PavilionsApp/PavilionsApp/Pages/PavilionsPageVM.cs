using CybersportApp.Pages;
using PavilionsApp.Connection.PavilionsEntities;
using PavilionsApp.Core;
using PavilionsApp.Core.EntitiesForList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionsApp.Pages
{
    public class PavilionsPageVM : INotifyPropertyChanged
    {
        private string _floor { get; set; }

        public string Floor
        {
            get { return _floor; }
            set
            {
                _floor = value;
                OnPropertyChanged("Floor");
            }
        }

        private ObservableCollection<string> _floors { get; set; }

        public ObservableCollection<string> Floors
        {
            get { return _floors; }
            set
            {
                _floors = value;
                OnPropertyChanged("Floors");
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

        private string _square { get; set; }

        public string Square
        {
            get { return _square; }
            set
            {
                _square = value;
                OnPropertyChanged("Square");
            }
        }

        private ObservableCollection<string> _squares { get; set; }

        public ObservableCollection<string> Squares
        {
            get { return _squares; }
            set
            {
                _squares = value;
                OnPropertyChanged("Squares");
            }
        }

        private PavilionsForList _selectedPavilion { get; set; }

        public PavilionsForList SelectedPavilion
        {
            get { return _selectedPavilion; }
            set
            {
                _selectedPavilion = value;
                OnPropertyChanged("SelectedPavilion");
            }
        }

        private ObservableCollection<PavilionsForList> _pavilionsList { get; set; }

        public ObservableCollection<PavilionsForList> PavilionsList
        {
            get { return _pavilionsList; }
            set
            {
                _pavilionsList = value;
                OnPropertyChanged("PavilionsList");
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
                        PavilionsNavigation.Service.Navigate(new ShoppingCentersPage());
                    }));
            }
        }

        private RelayCommand _addPavilion { get; set; }

        public RelayCommand AddPavilion
        {
            get
            {
                return _addPavilion ??
                    (_addPavilion = new RelayCommand(x =>
                    {
                        PavilionsNavigation.Service.Navigate(new PavilionsAddingPage());
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
                        if (SelectedPavilion != null)
                        {

                            PavilionsNavigation.Pavilion = SelectedPavilion;
                            PavilionsNavigation.PavilionCode = PavilionsCore.GetPavilionId(SelectedPavilion.PavilionNumber);

                            if (PavilionsNavigation.ShoppingCenter.Status != "Забронирован"
                                && PavilionsNavigation.ShoppingCenter.Status != "Арендован")
                                PavilionsNavigation.Service.Navigate(new PavilionsEditorPage());
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
                        Floor = null;
                        Square = null;
                        Status = null;

                        PavilionsList = PavilionsCore.Pavilions;
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
                        if (Floor == null
                            && Status == null
                            && Square == null)
                            PavilionsList = PavilionsCore.Pavilions;

                        if (Floor != null
                            && Status == null
                            && Square == null)
                            PavilionsList = PavilionsCore.FilterByFloor(Floor);

                        if (Floor == null
                            && Status != null
                            && Square == null)
                            PavilionsList = PavilionsCore.FilterByStatus(Status);

                        if (Floor == null
                            && Status == null
                            && Square != null)
                            PavilionsList = PavilionsCore.FilterBySquare(Square);

                        if (Floor != null
                           && Status != null
                           && Square == null)
                            PavilionsList = PavilionsCore.FilterByFloorAndStatus(Floor, Status);

                        if (Floor != null
                           && Status == null
                           && Square != null)
                            PavilionsList = PavilionsCore.FilterByFloorAndSquare(Floor, Square);

                        if (Floor == null
                           && Status != null
                           && Square != null)
                            PavilionsList = PavilionsCore.FilterByStatusAndSquare(Status, Square);

                        if (Floor != null
                           && Status != null
                           && Square != null)
                            PavilionsList = PavilionsCore.FilterByAll(Floor, Status, Square);
                    }));
            }
        }

        public PavilionsPageVM()
        {
            Floors = new ObservableCollection<string>();

            for (int i = 0; i < PavilionsCore.GetFloors(PavilionsNavigation.CenterCode); i++)
            {
                Floors.Add((i + 1).ToString());
            }

            Statuses = PavilionsCore.GetPavilionsStatusesNames();

            Squares = new ObservableCollection<string>();
            Squares.Add("<=100");
            Squares.Add("100-150");
            Squares.Add(">=150");

            PavilionsCore.GetPavilionsForList(PavilionsNavigation.CenterCode);
            PavilionsList = PavilionsCore.Pavilions;
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

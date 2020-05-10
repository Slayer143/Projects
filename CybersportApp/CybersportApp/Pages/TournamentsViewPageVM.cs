using CybersportApp.Core;
using CybersportApp.Core.ModelsForList;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CybersportApp.Pages
{
    public class TournamentsViewPageVM : INotifyPropertyChanged
    {
        private string _addRowHeight { get; set; }

        public string AddRowHeight
        {
            get { return _addRowHeight; }
            set
            {
                _addRowHeight = value;
                OnPropertyChanged("AddRowHeight");
            }
        }

        private string _lastRowHeight { get; set; }

        public string LastRowHeight
        {
            get { return _lastRowHeight; }
            set
            {
                _lastRowHeight = value;
                OnPropertyChanged("LastRowHeight");
            }
        }

        private bool _addIsEnableControl { get; set; }

        public bool AddIsEnableControl
        {
            get { return _addIsEnableControl; }
            set
            {
                _addIsEnableControl = value;
                OnPropertyChanged("AddIsEnableControl");
            }
        }

        private bool _addVisibilityControl { get; set; }

        public bool AddVisibilityControl
        {
            get { return _addVisibilityControl; }
            set
            {
                _addVisibilityControl = value;
                OnPropertyChanged("AddVisibilityControl");
            }
        }

        private ObservableCollection<TournamentsForList> _tournamentsList { get; set; }

        public ObservableCollection<TournamentsForList> TournamentsList
        {
            get { return _tournamentsList; }
            set
            {
                _tournamentsList = value;
                OnPropertyChanged("TournamentsList");
            }
        }

        private RelayCommand _addTournament { get; set; }

        public RelayCommand AddTournament
        {
            get
            {
                return _addTournament ??
                    (_addTournament = new RelayCommand(x =>
                    {
                        CybersportAppNavigation.Service.Navigate(new TournamentAddingPage());
                    }));
            }
        }

        public TournamentsViewPageVM()
        {
            TournamentsList = CybersportCore.GetTournaments();

            if (CybersportAppNavigation.CurrentUser.RoleId != 1)
            {
                AddRowHeight = "0";
                LastRowHeight = "1*";
                AddVisibilityControl = false;
                AddIsEnableControl = false;
            }
            else
            {
                AddRowHeight = "9*";
                LastRowHeight = "91*";
                AddVisibilityControl = true;
                AddIsEnableControl = true;
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

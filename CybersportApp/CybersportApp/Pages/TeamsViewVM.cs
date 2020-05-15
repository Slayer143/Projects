using CybersportApp.Core;
using CybersportApp.Core.ModelsForList;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CybersportApp.Pages
{
    public class TeamsViewVM : INotifyPropertyChanged
    {
        private string _finder { get; set; }

        public string Finder
        {
            get { return _finder; }
            set
            {
                _finder = value;
                OnPropertyChanged("Finder");
            }
        }

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

        private ObservableCollection<TeamsForList> _teamsList { get; set; }

        public ObservableCollection<TeamsForList> TeamsList
        {
            get { return _teamsList; }
            set
            {
                _teamsList = value;
                OnPropertyChanged("TeamsList");
            }
        }

        private RelayCommand _addTeam { get; set; }

        public RelayCommand AddTeam
        {
            get
            {
                return _addTeam ??
                    (_addTeam = new RelayCommand(x =>
                    {
                        CybersportAppNavigation.Service.Navigate(new TeamAddingPage());
                    }));
            }
        }

        private RelayCommand _useFinder { get; set; }

        public RelayCommand UseFinder
        {
            get
            {
                return _useFinder ??
                    (_useFinder = new RelayCommand(x =>
                    {
                        if (Finder == null
                          || Finder == string.Empty)
                            TeamsList = CybersportCore.GetTeams();
                        else
                        {
                            TeamsList.Clear();

                            foreach (var team in CybersportCore.GetTeams())
                            {
                                if (team.Name.Contains(Finder))
                                    TeamsList.Add(team);
                            }
                        }
                    }));
            }
        }

        public TeamsViewVM()
        {
            TeamsList = CybersportCore.GetTeams();

            if (CybersportAppNavigation.CurrentUser.RoleId != 1)
            {
                AddRowHeight = "0";
                LastRowHeight = "2*";
                AddVisibilityControl = false;
                AddIsEnableControl = false;
            }
            else
            {
                AddRowHeight = "0.3*";
                LastRowHeight = "1.4*";
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

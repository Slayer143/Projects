using CybersportApp.Core;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace CybersportApp.Pages
{
    public class TeamAddingPageVM : INotifyPropertyChanged
    {
        private Visibility _errorMessageVisibilityControl { get; set; }

        public Visibility ErrorMessageVisibilityControl
        {
            get { return _errorMessageVisibilityControl; }
            set
            {
                _errorMessageVisibilityControl = value;
                OnPropertyChanged("ErrorMessageVisibilityControl");
            }
        }

        private string _teamName { get; set; }

        public string TeamName
        {
            get { return _teamName; }
            set
            {
                _teamName = value;
                OnPropertyChanged("TeamName");
            }
        }

        private string _shortName { get; set; }

        public string ShortName
        {
            get { return _shortName; }
            set
            {
                _shortName = value;
                OnPropertyChanged("ShortName");
            }
        }

        private ObservableCollection<string> _disciplines { get; set; }

        public ObservableCollection<string> Disciplines
        {
            get { return _disciplines; }
            set
            {
                _disciplines = value;
                OnPropertyChanged("Disciplines");
            }
        }

        private string _discipline { get; set; }

        public string Discipline
        {
            get { return _discipline; }
            set
            {
                _discipline = value;
                OnPropertyChanged("Discipline");
            }
        }

        private ObservableCollection<string> countries { get; set; }

        public ObservableCollection<string> Countries
        {
            get { return countries; }
            set
            {
                countries = value;
                OnPropertyChanged("Countries");
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

        private RelayCommand _cancel { get; set; }

        public RelayCommand Cancel
        {
            get
            {
                return _cancel ??
                    (_cancel = new RelayCommand(x =>
                    {
                        CybersportAppNavigation.Service.GoBack();
                    }));
            }
        }

        private RelayCommand _save { get; set; }

        public RelayCommand Save
        {
            get
            {
                return _save ??
                    (_save = new RelayCommand(x =>
                    {
                        if (AllStated())
                        {
                            CybersportCore.AddTeam(TeamName, ShortName, Discipline, Country);

                            CybersportAppNavigation.CurrentTeamsPage = new TeamsViewPage();
                            CybersportAppNavigation.Service.GoBack();

                            ErrorMessageVisibilityControl = Visibility.Hidden;
                        }
                        else
                            ShowMessage();
                    }));
            }
        }

        public TeamAddingPageVM()
        {
            Countries = new ObservableCollection<string>(CybersportCore.GetCountries());

            CybersportCore.GetDisciplinesNames();
            Disciplines = new ObservableCollection<string>();

            foreach (var discipline in CybersportCore.DisciplinesCollection)
            {
                if (discipline.DisciplineId != 0)
                    Disciplines.Add(discipline.Name);
            }

            ErrorMessageVisibilityControl = Visibility.Hidden;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }

        private bool AllStated()
        {
            if (TeamName != null
               && ShortName != null
               && Discipline != null
               && Country != null)
            {
                if (TeamName != string.Empty
                    && ShortName != string.Empty
                    && Discipline != string.Empty
                    && Country != string.Empty)
                    return true;
            }

            return false;
        }

        private void ShowMessage()
        {
            ErrorMessageVisibilityControl = Visibility.Visible;
        }
    }
}

using CybersportApp.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace CybersportApp.Pages
{
    public class TournamentAddingPageVM : INotifyPropertyChanged
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

        private string _name { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _prizePool { get; set; }

        public string PrizePool
        {
            get { return _prizePool; }
            set
            {
                _prizePool = value;
                OnPropertyChanged("PrizePool");
            }
        }

        private string _firstPrize { get; set; }

        public string FirstPrize
        {
            get { return _firstPrize; }
            set
            {
                _firstPrize = value;
                OnPropertyChanged("FirstPrize");
            }
        }

        private string _secondPrize { get; set; }

        public string SecondPrize
        {
            get { return _secondPrize; }
            set
            {
                _secondPrize = value;
                OnPropertyChanged("SecondPrize");
            }
        }

        private string _thirdPrize { get; set; }

        public string ThirdPrize
        {
            get { return _thirdPrize; }
            set
            {
                _thirdPrize = value;
                OnPropertyChanged("ThirdPrize");
            }
        }

        private string _startDate { get; set; }

        public string StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        private string _endDate { get; set; }

        public string EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        private string _participants { get; set; }

        public string Participants
        {
            get { return _participants; }
            set
            {
                _participants = value;
                OnPropertyChanged("Participants");
            }
        }

        private ObservableCollection<string> _tournamentTypes { get; set; }

        public ObservableCollection<string> TournamentTypes
        {
            get { return _tournamentTypes; }
            set
            {
                _tournamentTypes = value;
                OnPropertyChanged("TournamentTypes");
            }
        }

        private string _tournamentType { get; set; }

        public string TournamentType
        {
            get { return _tournamentType; }
            set
            {
                _tournamentType = value;
                OnPropertyChanged("TournamentType");
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

        private RelayCommand _cancel { get; set; }

        public RelayCommand Cancel
        {
            get
            {
                return _cancel ??
                    (_cancel = new RelayCommand(x =>
                    {
                        CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentTournamentsPage);
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
                        if (AllStated()
                        && AllCorrect())
                        {
                            CybersportCore.AddTournament(
                                Name,
                                PrizePool,
                                FirstPrize,
                                SecondPrize,
                                ThirdPrize,
                                StartDate,
                                EndDate,
                                Participants,
                                TournamentType,
                                Discipline);

                            CybersportAppNavigation.CurrentTournamentsPage = new TournamentsViewPage();
                            CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentTournamentsPage);

                            ErrorMessageVisibilityControl = Visibility.Hidden;
                        }
                        else
                            ShowMessage();
                    }));
            }
        }

        public TournamentAddingPageVM()
        {
            TournamentTypes = CybersportCore.GetTournamentsTypes();


            Disciplines = new ObservableCollection<string>();
            CybersportCore.GetDisciplinesNames();

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
            if (Name != null
               || Name != string.Empty
               && PrizePool != null
               || PrizePool != string.Empty
               && FirstPrize != null
               || FirstPrize != string.Empty
               && SecondPrize != null
               || SecondPrize != string.Empty
               && ThirdPrize != null
               || ThirdPrize != string.Empty
               && StartDate != null
               || StartDate != string.Empty
               && EndDate != null
               || EndDate != string.Empty
               && Participants != null
               || Participants != string.Empty
               && TournamentType != null
               || TournamentType != string.Empty
               && Discipline != null
               || Discipline != string.Empty)
                return true;

            return false;
        }

        private bool AllCorrect()
        {
            if (DigitsOnly(PrizePool)
                && DigitsOnly(FirstPrize)
                && DigitsOnly(SecondPrize)
                && DigitsOnly(ThirdPrize)
                && DigitsOnly(Participants))
                return true;

            return false;
        }

        private bool DigitsOnly(string str)
        {
            if (str != null)
            {
                foreach (var ch in str)
                {
                    if (ch < '0' || ch > '9')
                        return false;
                }

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

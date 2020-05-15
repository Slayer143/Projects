using CybersportApp.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportApp.Pages
{
    public class AchievementAddingPageVM : INotifyPropertyChanged
    {
        private string _message { get; set; }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        private string _tournament { get; set; }

        public string Tournament
        {
            get { return _tournament; }
            set
            {
                _tournament = value;
                OnPropertyChanged("Tournament");
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

        private ObservableCollection<string> _tournaments { get; set; }

        public ObservableCollection<string> Tournaments
        {
            get { return _tournaments; }
            set
            {
                _tournaments = value;
                OnPropertyChanged("Tournaments");
            }
        }

        private string _place { get; set; }

        public string Place
        {
            get { return _place; }
            set
            {
                _place = value;
                OnPropertyChanged("Place");
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
                        if (CybersportAppNavigation.Service.CanGoBack)
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
                        if (Tournament != null
                        && Place != string.Empty)
                        {
                            if (DigitsOnly(Place))
                            {
                                if (Convert.ToInt32(Place) <= CybersportCore.GetParticipants(Tournament))
                                {
                                    CybersportCore.AddTournamentWin(CybersportAppNavigation.CurrentUser.UserId, Tournament, Convert.ToInt32(Place));
                                    CybersportAppNavigation.CurrentDetailsPage.DataContext = new DetailsPageVM();
                                    CybersportAppNavigation.Service.GoBack();
                                }
                                else
                                    Message = $"In the selected tournament are only {CybersportCore.GetParticipants(Tournament)} participants";
                            }
                            else
                                Message = "Field 'place' must content only digits!";
                        }
                        else
                            Message = "Fields can not be empty!";
                    }));
            }
        }

        public AchievementAddingPageVM()
        {
            Tournaments = CybersportCore.GetTournamentsNames();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
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
    }
}

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
    public class DetailsPageVM : INotifyPropertyChanged
    {
        private bool _isEnabledControl { get; set; }

        public bool IsEnabledControl
        {
            get { return _isEnabledControl; }
            set
            {
                _isEnabledControl = value;
                OnPropertyChanged("IsEnabledControl");
            }
        }

        private ObservableCollection<string> _raitings { get; set; }

        public ObservableCollection<string> Raitings
        {
            get { return _raitings; }
            set
            {
                _raitings = value;
                OnPropertyChanged("Raitings");
            }
        }

        private string _raiting { get; set; }

        public string Raiting
        {
            get { return _raiting; }
            set
            {
                _raiting = value;
                OnPropertyChanged("Raiting");
            }
        }

        private ObservableCollection<string> _accountStatuses { get; set; }

        public ObservableCollection<string> AccountStatuses
        {
            get { return _accountStatuses; }
            set
            {
                _accountStatuses = value;
                OnPropertyChanged("AccountStatuses");
            }
        }

        private string _accountStatus { get; set; }

        public string AccountStatus
        {
            get { return _accountStatus; }
            set
            {
                _accountStatus = value;
                OnPropertyChanged("AccountStatus");
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

        private string _totalEarnings { get; set; }

        public string TotalEarnings
        {
            get { return _totalEarnings; }
            set
            {
                _totalEarnings = value;
                OnPropertyChanged("TotalEarnings");
            }
        }

        private string _careerStart { get; set; }

        public string CareerStart
        {
            get { return _careerStart; }
            set
            {
                _careerStart = value;
                OnPropertyChanged("CareerStart");
            }
        }

        public DetailsPageVM()
        {
            if (CybersportAppNavigation.CurrentUserInfo != null)
            {
                if (CybersportAppNavigation.CurrentUserInfo.TotalEarnings.Equals(Convert.ToDecimal(0)))
                    TotalEarnings = "Not stated";
                else
                    TotalEarnings = CybersportAppNavigation.CurrentUserInfo.TotalEarnings.ToString();

                if (CybersportAppNavigation.CurrentUserInfo.CareerStartYear.Equals(0))
                    CareerStart = "Not stated";
                else
                    CareerStart = CybersportAppNavigation.CurrentUserInfo.CareerStartYear.ToString();
                
                Raiting = CybersportCore
                    .RatingsCollection
                    .FirstOrDefault(
                    x => x.RatingId == CybersportAppNavigation
                    .CurrentUserInfo
                    .RatingId).RatingValue;
               
                AccountStatus = CybersportCore
                    .AccountStatusesCollection
                    .FirstOrDefault(x => x.AccountStatusId == CybersportAppNavigation
                    .CurrentUserInfo
                    .AccountStatusId).Status;
                
                Discipline = CybersportCore
                    .DisciplinesCollection
                    .FirstOrDefault(x => x.DisciplineId == CybersportAppNavigation
                .CurrentUserInfo
                .DisciplineId).Name;

                IsEnabledControl = false;
            }
            else
            {
                IsEnabledControl = true;
                Disciplines = CybersportCore.GetDisciplinesNames();
                AccountStatuses = CybersportCore.GetAccountStatusesNames();
                Raitings = CybersportCore.GetRaitingsNames();
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

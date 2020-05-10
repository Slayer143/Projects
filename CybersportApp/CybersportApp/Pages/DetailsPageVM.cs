using CybersportApp.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace CybersportApp.Pages
{
    public class DetailsPageVM : INotifyPropertyChanged
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

        private string _login { get; set; }

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        private Visibility _verifyVisibilityControl { get; set; }

        public Visibility VerifyVisibilityControl
        {
            get { return _verifyVisibilityControl; }
            set
            {
                _verifyVisibilityControl = value;
                OnPropertyChanged("VerifyVisibilityControl");
            }
        }

        private bool _verifyIsEnabledControl { get; set; }

        public bool VerifyIsEnabledControl
        {
            get { return _verifyIsEnabledControl; }
            set
            {
                _verifyIsEnabledControl = value;
                OnPropertyChanged("VerifyIsEnabledControl");
            }
        }

        private Visibility _anotherUserVisibilityControl { get; set; }

        public Visibility AnotherUserVisibilityControl
        {
            get { return _anotherUserVisibilityControl; }
            set
            {
                _anotherUserVisibilityControl = value;
                OnPropertyChanged("AnotherUserVisibilityControl");
            }
        }

        private bool _anotherUserIsEnabledControl { get; set; }

        public bool AnotherUserIsEnabledControl
        {
            get { return _anotherUserIsEnabledControl; }
            set
            {
                _anotherUserIsEnabledControl = value;
                OnPropertyChanged("AnotherUserIsEnabledControl");
            }
        }

        private Visibility _editVisibilityControl { get; set; }

        public Visibility EditVisibilityControl
        {
            get { return _editVisibilityControl; }
            set
            {
                _editVisibilityControl = value;
                OnPropertyChanged("EditVisibilityControl");
            }
        }

        private bool _editIsEnabledControl { get; set; }

        public bool EditIsEnabledControl
        {
            get { return _editIsEnabledControl; }
            set
            {
                _editIsEnabledControl = value;
                OnPropertyChanged("EditIsEnabledControl");
            }
        }

        private Visibility _updateVisibilityControl { get; set; }

        public Visibility UpdateVisibilityControl
        {
            get { return _updateVisibilityControl; }
            set
            {
                _updateVisibilityControl = value;
                OnPropertyChanged("UpdateVisibilityControl");
            }
        }

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

        private ObservableCollection<string> _ratings { get; set; }

        public ObservableCollection<string> Ratings
        {
            get { return _ratings; }
            set
            {
                _ratings = value;
                OnPropertyChanged("Ratings");
            }
        }

        private string _rating { get; set; }

        public string Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                OnPropertyChanged("Rating");
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

        private RelayCommand _save;
        public RelayCommand Save
        {
            get
            {
                return _save ??
                    (_save = new RelayCommand(x =>
                    {
                        if (CybersportAppNavigation.CurrentUserInfo == null
                        && AllCorrect())
                        {
                            CybersportCore.AddDetailedInfo(
                                CybersportAppNavigation.CurrentUser.UserId,
                                Rating,
                                Discipline,
                                AccountStatus,
                                Convert.ToDecimal(TotalEarnings),
                                Convert.ToInt32(CareerStart));

                            IsEnabledControl = false;
                            UpdateVisibilityControl = Visibility.Hidden;
                        }
                            
                        else
                        {
                            if (AllCorrect())
                            {
                                CybersportCore.UpdateDetailedInfo(
                                CybersportAppNavigation.CurrentUser.UserId,
                                Rating,
                                Discipline,
                                AccountStatus,
                                Convert.ToDecimal(TotalEarnings),
                                Convert.ToInt32(CareerStart));

                                ErrorMessageVisibilityControl = Visibility.Hidden;

                                IsEnabledControl = false;
                                UpdateVisibilityControl = Visibility.Hidden;
                            }
                            else
                                ShowMessage();
                        }
                    }));
            }
        }

        private RelayCommand _edit;
        public RelayCommand Edit
        {
            get
            {
                return _edit ??
                    (_edit = new RelayCommand(x =>
                    {
                        IsEnabledControl = true;
                        UpdateVisibilityControl = Visibility.Visible;

                        if (AccountStatus == "Verified")
                        {
                            VerifyIsEnabledControl = false;
                            VerifyVisibilityControl = Visibility.Hidden;
                        }
                        else
                        {
                            VerifyIsEnabledControl = true;
                            VerifyVisibilityControl = Visibility.Visible;
                        }
                    }));
            }
        }

        private RelayCommand _cancel;
        public RelayCommand Cancel
        {
            get
            {
                return _cancel ??
                    (_cancel = new RelayCommand(x =>
                    {
                        IsEnabledControl = false;
                        UpdateVisibilityControl = Visibility.Hidden;
                        VerifyIsEnabledControl = false;
                        VerifyVisibilityControl = Visibility.Hidden;

                        CybersportAppNavigation.CurrentDetailsPage.DataContext = new DetailsPageVM();
                    }));
            }
        }

        private RelayCommand _verify;
        public RelayCommand Verify
        {
            get
            {
                return _verify ??
                    (_verify = new RelayCommand(x =>
                    {
                        if (CybersportAppNavigation.CurrentUser.RoleId == 1)
                        {
                            CybersportCore.VerifyAccount(Login);
                            CybersportAppNavigation.CurrentDetailsPage.DataContext = new DetailsPageVM(Login);
                        }
                        else
                            CybersportCore.AskToVerifyAccount(CybersportAppNavigation.CurrentUser.UserId);

                        VerifyIsEnabledControl = false;
                        VerifyVisibilityControl = Visibility.Hidden;
                    }));
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

        public DetailsPageVM()
        {
            CybersportCore.GetDisciplinesNames();

            CybersportCore.GetRaitingsNames();

            CybersportCore.GetAccountStatusesNames();

            Disciplines = new ObservableCollection<string>();

            foreach (var discipline in CybersportCore.DisciplinesCollection)
            {
                if (discipline.DisciplineId != 0)
                    Disciplines.Add(discipline.Name);
            }

            Ratings = new ObservableCollection<string>();

            foreach (var rating in CybersportCore.RatingsCollection)
            {
                Ratings.Add(rating.RatingValue);
            }

            if (CybersportAppNavigation.CurrentUserInfo != null)
            {
                TotalEarnings = CybersportAppNavigation.CurrentUserInfo.TotalEarnings.ToString();

                if (CybersportAppNavigation.CurrentUserInfo.CareerStartYear.Equals(0))
                    CareerStart = "Not stated";
                else
                    CareerStart = CybersportAppNavigation.CurrentUserInfo.CareerStartYear.ToString();

                Rating = CybersportCore
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

                UpdateVisibilityControl = Visibility.Hidden;
            }
            else
            {
                IsEnabledControl = true;
                UpdateVisibilityControl = Visibility.Visible;

                AccountStatus = "Not verified";
            }

            EditVisibilityControl = Visibility.Visible;
            EditIsEnabledControl = true;
            AnotherUserIsEnabledControl = false;
            AnotherUserVisibilityControl = Visibility.Hidden;
            VerifyIsEnabledControl = false;
            VerifyVisibilityControl = Visibility.Hidden;
            ErrorMessageVisibilityControl = Visibility.Hidden;
        }

        public DetailsPageVM(string login)
        {
            Login = login;

            CybersportCore.GetDisciplinesNames();

            CybersportCore.GetRaitingsNames();

            CybersportCore.GetAccountStatusesNames();

            Disciplines = new ObservableCollection<string>();

            foreach (var discipline in CybersportCore.DisciplinesCollection)
            {
                if (discipline.DisciplineId != 0)
                    Disciplines.Add(discipline.Name);
            }

            Ratings = new ObservableCollection<string>();

            foreach (var rating in CybersportCore.RatingsCollection)
            {
                Ratings.Add(rating.RatingValue);
            }

            var userInfo = CybersportCore.GetUserInfo(login);

            if (userInfo != null)
            {
                TotalEarnings = userInfo.TotalEarnings.ToString();

                if (userInfo.CareerStartYear.Equals(0))
                    CareerStart = "Not stated";
                else
                    CareerStart = userInfo.CareerStartYear.ToString();

                Rating = CybersportCore
                    .RatingsCollection
                    .FirstOrDefault(
                    x => x.RatingId == userInfo
                    .RatingId).RatingValue;

                AccountStatus = CybersportCore
                    .AccountStatusesCollection
                    .FirstOrDefault(x => x.AccountStatusId == userInfo
                    .AccountStatusId).Status;

                Discipline = CybersportCore
                    .DisciplinesCollection
                    .FirstOrDefault(x => x.DisciplineId == userInfo
                .DisciplineId).Name;
            }

            UpdateVisibilityControl = Visibility.Hidden;
            IsEnabledControl = false;
            EditVisibilityControl = Visibility.Hidden;
            EditIsEnabledControl = false;
            ErrorMessageVisibilityControl = Visibility.Hidden;

            AnotherUserIsEnabledControl = true;
            AnotherUserVisibilityControl = Visibility.Visible;

            if (CybersportAppNavigation.CurrentUser.RoleId == 1)
            {
                if (AccountStatus == "Not verified")
                {
                    VerifyIsEnabledControl = true;
                    VerifyVisibilityControl = Visibility.Visible;
                }
                else
                {
                    VerifyIsEnabledControl = false;
                    VerifyVisibilityControl = Visibility.Hidden;
                }
            }
            else
            {
                VerifyIsEnabledControl = false;
                VerifyVisibilityControl = Visibility.Hidden;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }

        private bool AllCorrect()
        {
            if (DigitsOnly(TotalEarnings)
               && DigitsOnly(CareerStart))
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

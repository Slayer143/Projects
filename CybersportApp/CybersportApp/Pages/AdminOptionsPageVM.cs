using CybersportApp.Core;
using System.ComponentModel;

namespace CybersportApp.Pages
{
    public class AdminOptionsPageVM : INotifyPropertyChanged
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

        private string _disciplineName { get; set; }

        public string DisciplineName
        {
            get { return _disciplineName; }
            set
            {
                _disciplineName = value;
                OnPropertyChanged("DisciplineName");
            }
        }

        private string _countryName { get; set; }

        public string CountryName
        {
            get { return _countryName; }
            set
            {
                _countryName = value;
                OnPropertyChanged("CountryName");
            }
        }

        private string _ratingValue { get; set; }

        public string RatingValue
        {
            get { return _ratingValue; }
            set
            {
                _ratingValue = value;
                OnPropertyChanged("RatingValue");
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

        private RelayCommand _saveDiscipline { get; set; }

        public RelayCommand SaveDiscipline
        {
            get
            {
                return _saveDiscipline ??
                    (_saveDiscipline = new RelayCommand(x =>
                    {
                        if (DisciplineName != null
                            && DisciplineName != string.Empty)
                        {
                            if (CybersportCore.DisciplineNameIsNotReserved(DisciplineName))
                            {
                                CybersportCore.AddDiscipline(DisciplineName);
                                Message = "Discipline is saved";
                            }
                            else
                            Message = "Discipline name already exists";
                        }
                        else
                            Message = "Discipline name can not be empty";
                    }));
            }
        }

        private RelayCommand _saveCountry{ get; set; }

        public RelayCommand SaveCountry
        {
            get
            {
                return _saveCountry ??
                    (_saveCountry = new RelayCommand(x =>
                    {
                        if (CountryName != null
                            && CountryName != string.Empty)
                        {
                            if (CybersportCore.CountryNameIsNotReserved(CountryName))
                            {
                                CybersportCore.AddCountry(CountryName);
                                Message = "Country is saved";
                            }
                            else
                                Message = "Country name already exists";
                        }
                        else
                            Message = "Country name can not be empty";
                    }));
            }
        }

        private RelayCommand _saveRating { get; set; }

        public RelayCommand SaveRating
        {
            get
            {
                return _saveRating ??
                    (_saveRating = new RelayCommand(x =>
                    {
                        if (RatingValue != null
                            && RatingValue != string.Empty)
                        {
                            if (CybersportCore.RatingValueIsNotReserved(RatingValue))
                            {
                                CybersportCore.AddRating(RatingValue);
                                Message = "Rating is saved";
                            }
                            else
                                Message = "Rating value already exists";
                        }
                        else
                            Message = "Rating value can not be empty";
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

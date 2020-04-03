using System.Collections.ObjectModel;
using System.ComponentModel;
using VacancyAppointment.Connection;

namespace VacancyAppointment
{
    public class VacanciesToAppointSearchVM : INotifyPropertyChanged
    {
        private string _header { get; set; }

        public string Header
        {
            get { return _header; }
            set
            {
                _header = value;
                OnPropertyChanged("Header");
            }
        }

        private ObservableCollection<VacancyToAppoint> _vacancies { get; set; }

        public ObservableCollection<VacancyToAppoint> Vacancies
        {
            get { return _vacancies; }
            set
            {
                _vacancies = value;
                OnPropertyChanged("Vacancies");
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

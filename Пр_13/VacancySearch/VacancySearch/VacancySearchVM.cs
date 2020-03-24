using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancySearch.Connection;

namespace VacancySearch
{
    public class VacancySearchVM : INotifyPropertyChanged
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

        private ObservableCollection<Vacancy> _vacancies { get; set; }

        public ObservableCollection<Vacancy> Vacancies
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

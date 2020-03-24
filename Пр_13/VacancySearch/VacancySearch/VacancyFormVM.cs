using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancySearch
{
    class VacancyFormVM : INotifyPropertyChanged
    {
        private string _subName { get; set; }

        public string SubName
        {
            get { return _subName; }
            set
            {
                _subName = value;
                OnPropertyChanged("SubName");
            }
        }

        private string _posName { get; set; }

        public string PosName
        {
            get { return _posName; }
            set
            {
                _posName = value;
                OnPropertyChanged("PosName");
            }
        }

        private string _lastName { get; set; }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
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

        private string _secondName { get; set; }

        public string SecondName
        {
            get { return _secondName; }
            set
            {
                _secondName = value;
                OnPropertyChanged("SecondName");
            }
        }

        private char _gender { get; set; }

        public char Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged("Gender");
            }
        }

        private char[] _genders { get; set; }

        public char[] Genders
        {
            get { return _genders; }
            set
            {
                _genders = value;
                OnPropertyChanged("Genders");
            }
        }

        private string _educationLevel { get; set; }

        public string EducationLevel
        {
            get { return _educationLevel; }
            set
            {
                _educationLevel = value;
                OnPropertyChanged("EducationLevel");
            }
        }

        private string _birthDate { get; set; }

        public string BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        private string _phoneNumber { get; set; }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public VacancyFormVM(string subName, string posName)
        {
            Genders = new char[] { 'м', 'ж' };
            SubName = subName;
            PosName = posName;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}

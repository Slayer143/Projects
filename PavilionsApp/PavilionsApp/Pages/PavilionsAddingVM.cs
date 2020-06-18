using CybersportApp.Pages;
using PavilionsApp.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionsApp.Pages
{
    public class PavilionsAddingVM : INotifyPropertyChanged
    {
        private string _floor { get; set; }

        public string Floor
        {
            get { return _floor; }
            set
            {
                _floor = value;
                OnPropertyChanged("Floor");
            }
        }

        private ObservableCollection<string> _floors { get; set; }

        public ObservableCollection<string> Floors
        {
            get { return _floors; }
            set
            {
                _floors = value;
                OnPropertyChanged("Floors");
            }
        }

        private string _status { get; set; }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        private ObservableCollection<string> _statuses { get; set; }

        public ObservableCollection<string> Statuses
        {
            get { return _statuses; }
            set
            {
                _statuses = value;
                OnPropertyChanged("Statuses");
            }
        }

        private string _square { get; set; }

        public string Square
        {
            get { return _square; }
            set
            {
                _square = value;
                OnPropertyChanged("Square");
            }
        }

        private string _number { get; set; }

        public string Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }

        private string _valueFactor { get; set; }

        public string ValueFactor
        {
            get { return _valueFactor; }
            set
            {
                _valueFactor = value;
                OnPropertyChanged("ValueFactor");
            }
        }

        private string _cost { get; set; }

        public string Cost
        {
            get { return _cost; }
            set
            {
                _cost = value;
                OnPropertyChanged("Cost");
            }
        }

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

        private RelayCommand _back { get; set; }

        public RelayCommand Back
        {
            get
            {
                return _back ??
                    (_back = new RelayCommand(x =>
                    {
                        if (PavilionsNavigation.Service.CanGoBack)
                            PavilionsNavigation.Service.GoBack();
                    }));
            }
        }

        private RelayCommand _add { get; set; }

        public RelayCommand Add
        {
            get
            {
                return _add ??
                    (_add = new RelayCommand(x =>
                    {
                        if (AllStated())
                        {
                            if (DigitsOnly(Cost)
                                && DigitsOnly(Square)
                                && DigitsOnly(ValueFactor))
                            {
                                if (Convert.ToDecimal(ValueFactor) > Convert.ToDecimal("0,1"))
                                {
                                    PavilionsCore.FormPavilion(
                                        Number,
                                        Floor,
                                        Status,
                                        Square,
                                        Cost,
                                        ValueFactor,
                                        PavilionsNavigation.CenterCode);


                                    PavilionsNavigation.Service.Navigate(new PavilionsPage());
                                }
                                else
                                    Message = "Значение поля добавочная стоимость должно быть больше 0,1";
                            }
                            else
                                Message = "Поля добавочная стоимость," +
                                " площадь и стоимость за кв. метр, " +
                                " должны содержать только цифры";
                        }
                        else
                            Message = "Все поля являются обязательными";
                    }));
            }
        }

        public PavilionsAddingVM()
        {
            Floors = new ObservableCollection<string>();

            for (int i = 0; i < PavilionsCore.GetFloors(PavilionsNavigation.CenterCode); i++)
            {
                Floors.Add((i + 1).ToString());
            }

            Statuses = PavilionsCore.GetPavilionsStatusesNames();
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
            return Floor != null
               && Floor != string.Empty
               && Number != null
               && Number != string.Empty
               && Square != null
               && Square != string.Empty
               && Status != null
               && Status != string.Empty
               && ValueFactor != null
               && ValueFactor != string.Empty
               && Cost != null
               && Cost != string.Empty;
        }

        private bool DigitsOnly(string input)
        {
            foreach (char letter in input)
            {
                if (letter < '0' || letter > '9')
                    return false;
            }

            return true;
        }
    }
}

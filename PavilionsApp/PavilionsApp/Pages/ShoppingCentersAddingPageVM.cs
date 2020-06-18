using CybersportApp.Pages;
using Microsoft.Win32;
using PavilionsApp.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PavilionsApp.Pages
{
    public class ShoppingCentersAddingPageVM : INotifyPropertyChanged
    {
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

        private string _city { get; set; }

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }

        private string _pavilions { get; set; }

        public string Pavilions
        {
            get { return _pavilions; }
            set
            {
                _pavilions = value;
                OnPropertyChanged("Pavilions");
            }
        }

        private string _floors { get; set; }

        public string Floors
        {
            get { return _floors; }
            set
            {
                _floors = value;
                OnPropertyChanged("Floors");
            }
        }

        private byte[] _photo { get; set; }

        public byte[] Photo
        {
            get { return _photo; }
            set
            {
                _photo = value;
                OnPropertyChanged("Photo");
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

        private RelayCommand _choosePhoto { get; set; }

        public RelayCommand ChoosePhoto
        {
            get
            {
                return _choosePhoto ??
                    (_choosePhoto = new RelayCommand(x =>
                    {
                        var fileDialog = new OpenFileDialog();
                        fileDialog.Filter = "Image Files | *.BMP;*.JPG;*.PNG";

                        if (fileDialog.ShowDialog() == true)
                        {
                            using (FileStream stream = new FileStream(fileDialog.FileName, FileMode.Open))
                            {
                                byte[] imageData = new byte[stream.Length];
                                stream.Read(imageData, 0, imageData.Length);
                                Photo = imageData;
                            }
                        }
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
                        var validFactor = ValueFactor;

                        if (AllStated())
                        {
                            if (DigitsOnly(Cost)
                                && validFactor[1] == ','
                                && DigitsOnly(validFactor.Remove(1))
                                && DigitsOnly(Pavilions)
                                && DigitsOnly(Floors))
                            {
                                if (Convert.ToDecimal(ValueFactor) > Convert.ToDecimal("0,1"))
                                {
                                    PavilionsCore.FormShoppingCenter(
                                        Name,
                                        Status,
                                        ValueFactor,
                                        Cost,
                                        City,
                                        Pavilions,
                                        Floors,
                                        Photo);

                                    PavilionsNavigation.Service.Navigate(new ShoppingCentersPage());
                                }
                                else
                                    Message = "Значение поля добавочная стоимость должно быть больше 0,1";
                            }
                            else
                                Message = "Поля добавочная стоимость (дробная часть отделяется запятой)," +
                                " затраты на строительство, " +
                                "кол-во павильонов и этажность" +
                                " должны содержать только цифры";
                        }
                        else
                            Message = "Все поля являются обязательными, кроме фотографии";
                    }));
            }
        }

        public ShoppingCentersAddingPageVM()
        {
            Statuses = PavilionsCore.GetStatusesNames();
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
            return Name != null
                && Name != string.Empty
                && ValueFactor != null
                && ValueFactor != string.Empty
                && Cost != null
                && Cost != string.Empty
                && Status != null
                && Status != string.Empty
                && City != null
                && City != string.Empty
                && Pavilions != null
                && Pavilions != string.Empty
                && Floors != null
                && Floors != string.Empty;
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

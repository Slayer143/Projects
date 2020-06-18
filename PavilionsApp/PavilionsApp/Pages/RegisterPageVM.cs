using CybersportApp.Pages;
using Microsoft.Win32;
using PavilionsApp.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace PavilionsApp.Pages
{
    public class RegisterPageVM : INotifyPropertyChanged
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

        private string _password { get; set; }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
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

        private string _phone { get; set; }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
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

        private ObservableCollection<char> _genders { get; set; }

        public ObservableCollection<char> Genders
        {
            get { return _genders; }
            set
            {
                _genders = value;
                OnPropertyChanged("Genders");
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

        private RelayCommand _confirm { get; set; }
        public RelayCommand Confirm
        {
            get
            {
                return _confirm ??
                    (_confirm = new RelayCommand(x =>
                    {
                        if (DataIsNotNull())
                        {
                            if (AllIsCorrect())
                            {
                                PavilionsNavigation.CurrentUser = PavilionsCore.FormEmployee(
                                    Login, 
                                    Password, 
                                    LastName, 
                                    Name, 
                                    SecondName, 
                                    Phone, 
                                    Gender, 
                                    Photo);

                                switch (PavilionsNavigation.CurrentUser.RoleId)
                                {
                                    case 1:
                                        //PavilionsNavigation.Service.Navigate(new ManagerCPage());
                                        break;
                                    case 2:
                                        //PavilionsNavigation.Service.Navigate(new ManagerCPage());
                                        break;
                                    case 3:
                                        PavilionsNavigation.Service.Navigate(new ManagerCPage());
                                        break;
                                    case 4:
                                        //PavilionsNavigation.Service.Navigate(new ManagerCPage());
                                        break;
                                }
                            }
                            else
                                Message = "Минимальная длина логина и пароля 6 символов";
                        }
                        else
                            Message = "Все поля обязательны для заполнения, кроме поля Фото";
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

        public RegisterPageVM()
        {
            Genders = PavilionsCore.GetGendersNames();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }

        private bool DataIsNotNull()
        {
            return Login != null
                && Login != String.Empty
                && Password != null
                && Password != String.Empty
                && LastName != null
                && LastName != String.Empty
                && Name != null
                && Name != String.Empty
                && SecondName != null
                && SecondName != String.Empty
                && Phone != null
                && Phone != String.Empty
                && Gender.ToString() != null;
        }

        private bool AllIsCorrect()
        {
            return Login.Length > 6
                && Password.Length > 6;
        }
    }
}

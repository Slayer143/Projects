using CybersportApp.Pages;
using PavilionsApp.Connection.PavilionsEntities;
using PavilionsApp.Core;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PavilionsApp.Pages
{
    public class AuthPageVm : INotifyPropertyChanged
    {
        private int _captureCounter = 0;

        private Visibility _captureVisibility { get; set; }

        public Visibility CaptureVisibility
        {
            get { return _captureVisibility; }
            set
            {
                _captureVisibility = value;
                OnPropertyChanged("CaptureVisibility");
            }
        }

        private Brush _captureBack { get; set; }

        public Brush CaptureBack
        {
            get { return _captureBack; }
            set
            {
                _captureBack = value;
                OnPropertyChanged("CaptureBack");
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

        private string _captureCheck { get; set; }

        public string CaptureCheck
        {
            get { return _captureCheck; }
            set
            {
                _captureCheck = value;
                OnPropertyChanged("CaptureCheck");
            }
        }

        private string _captureText { get; set; }

        public string CaptureText
        {
            get { return _captureText; }
            set
            {
                _captureText = value;
                OnPropertyChanged("CaptureText");
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

        private RelayCommand _auth { get; set; }

        public RelayCommand Auth
        {
            get
            {
                return _auth ??
                    (_auth = new RelayCommand(x =>
                    {
                        if (_captureCounter < 2)
                        {
                            if (DataIsNotNull())
                            {
                                if (AuthIsCorrect())
                                {
                                    PavilionsNavigation.CurrentUser = PavilionsCore.GetEmployee(Login);

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
                                {
                                    Message = "Введены неверные данные";

                                    _captureCounter++;
                                }
                            }
                            else
                            {
                                Message = "Поля не могут быть пустыми";
                            }
                        }
                        else
                        {
                            CaptureVisibility = Visibility.Visible;
                            GenerateCapture();

                            if (AllDataIsNotNull())
                            {
                                if (AuthIsCorrect())
                                {
                                    PavilionsNavigation.CurrentUser = PavilionsCore.GetEmployee(Login);

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
                                {
                                    Message = "Введены неверные данные";
                                }
                            }
                            else
                            {
                                Message = "Поля не могут быть пустыми";
                            }
                        }
                    }));
            }
        }

        public AuthPageVm()
        {
            CaptureVisibility = Visibility.Hidden;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }

        private void GenerateCapture()
        {
            char[] symbols = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'r', 't', 'y', 'j', 'k', 'n', 'm', 'z', 'x', '1', '2', '3', '5', '6', '7', '8' };

            string captureContent = "";
            Random rand = new Random();
            double offsetCords = 0.00;

            LinearGradientBrush gradient = new LinearGradientBrush()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1)
            };

            for (int i = 0; i < 6; i++)
            {
                gradient.GradientStops.Add(
                    new GradientStop(
                        Color.FromArgb(
                            Convert.ToByte(rand.Next(255)),
                            Convert.ToByte(rand.Next(255)),
                            Convert.ToByte(rand.Next(255)),
                            Convert.ToByte(rand.Next(255))),
                        offsetCords)
                    );

                offsetCords += 0.15;
            }

            CaptureBack = gradient;

            captureContent += symbols[rand.Next(6)];
            captureContent += symbols[rand.Next(7, 15)];
            captureContent += symbols[rand.Next(16, 22)];
            captureContent += symbols[rand.Next(6)];
            captureContent += symbols[rand.Next(16, 22)];
            captureContent += symbols[rand.Next(7, 15)];
            captureContent += symbols[rand.Next(6)];

            CaptureText = captureContent;
        }

        private bool AuthIsCorrect()
        {
            return PavilionsCore.CheckAuth(Login, Password);
        }

        private bool DataIsNotNull()
        {
            return Login != null
                && Password != null;
        }

        private bool AllDataIsNotNull()
        {
            return Login != null
                && Password != null
                && CaptureCheck != null
                && CaptureCheck.ToLower() == CaptureText.ToLower();
        }
    }
}

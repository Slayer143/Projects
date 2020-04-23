using CybersportApp.Core;
using CybersportApp.Core.CybersportEntities;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace CybersportApp.Pages
{
    class AuthorizationPageVM : INotifyPropertyChanged
    {
        private BitmapImage _backgroundImage { get; set; }

        public BitmapImage BackgroundImage
        {
            get { return _backgroundImage; }
            set
            {
                _backgroundImage = value;
                OnPropertyChanged("BackgroundImage");
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

        private string _systemMessage { get; set; }

        public string SystemMessage
        {
            get { return _systemMessage; }
            set
            {
                _systemMessage = value;
                OnPropertyChanged("SystemMessage");
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

        private RelayCommand _checkUser { get; set; }

        public RelayCommand CheckUser
        {
            get
            {
                return _checkUser ??
                    (_checkUser = new RelayCommand(x =>
                    {
                        var user = CybersportCore.CheckUser(Login, Password);

                        if (user != null)
                        {
                            CybersportAppNavigation.CurrentUser = user;
                            CybersportAppNavigation.CurrentUserInfo = CybersportCore.GetUserInfo(user.UserId);

                            CybersportAppNavigation.CurrentWindow.DataContext = new MainWindowVM(CybersportAppNavigation.CurrentUser.RoleId);

                            if (CybersportAppNavigation.CurrentProfileMenuPage != null)
                                CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentProfileMenuPage);
                            else
                            {
                                CybersportAppNavigation.CurrentProfileMenuPage = new ProfileMenu();
                                CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentProfileMenuPage);
                            }
                        }
                        else
                            SystemMessage = "You entered wrong data";
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AuthorizationPageVM()
        {
            using (MemoryStream memory = new MemoryStream())
            {
                Properties.Resources.abstract_gradient_pink_purple_stripes_on_purple_background.Save(memory, ImageFormat.Jpeg);
                memory.Position = 0;
                BackgroundImage = new BitmapImage();
                BackgroundImage.BeginInit();
                BackgroundImage.StreamSource = memory;
                BackgroundImage.CacheOption = BitmapCacheOption.OnLoad;
                BackgroundImage.EndInit();
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}

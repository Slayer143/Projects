using CybersportApplication.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CybersportApplication.Pages
{
    class RegistrationPageVM : INotifyPropertyChanged
    {
        private byte[] _imageContent { get; set; }

        public byte[] ImageContent
        {
            get { return _imageContent; }
            set
            {
                _imageContent = value;
                OnPropertyChanged("ImageContent");
            }
        }

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

        private ObservableCollection<string> _countries { get; set; }

        public ObservableCollection<string> Countries
        {
            get { return _countries; }
            set
            {
                _countries = value;
                OnPropertyChanged("Countries");
            }
        }

        private string _country { get; set; }

        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged("Country");
            }
        }

        private ObservableCollection<string> _roles { get; set; }

        public ObservableCollection<string> Roles
        {
            get { return _roles; }
            set
            {
                _roles = value;
                OnPropertyChanged("Roles");
            }
        }

        private string _role { get; set; }

        public string Role
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged("Role");
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

        private DateTimeOffset _birthDate { get; set; }

        public DateTimeOffset BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        private RelayCommand _checkData { get; set; }

        public RelayCommand CheckData
        {
            get
            {
                return _checkData ??
                    (_checkData = new RelayCommand(x =>
                    {

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
                        if (CybersportNavigation.Service.CanGoBack)
                            CybersportNavigation.Service.GoBack();
                    }));
            }
        }

        private RelayCommand _getImage { get; set; }

        public RelayCommand GetImage
        {
            get
            {
                return _getImage ??
                    (_getImage = new RelayCommand(x =>
                    {
                        var fileDialog = new OpenFileDialog();
                        fileDialog.Filter = "Image Files | *.BMP;*.JPG;*.PNG";

                        if (fileDialog.ShowDialog() == true)
                        {
                            using (FileStream stream = new FileStream(fileDialog.FileName, FileMode.Open))
                            {
                                byte[] imageData = new byte[stream.Length];
                                stream.Read(imageData, 0, imageData.Length);
                                ImageContent = imageData;
                            }
                        }
                    }));
            }
        }

        public RegistrationPageVM()
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

            //foreach (var country in CybersportCore.GetCountries())
            //{
            //    Countries.Add(country.Name);
            //}

            CybersportCore.GetRoles();

            Countries = new ObservableCollection<string>();
            foreach (var country in CybersportCore.CountriesCollection)
            {
                Countries.Add(country.Name);
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

using CybersportApp.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CybersportApp
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private string _rowHeight { get; set; }

        public string RowHeight
        {
            get { return _rowHeight; }
            set
            {
                _rowHeight = value;
                OnPropertyChanged("RowHeight");
            }
        }

        private string _lastRowHeight { get; set; }

        public string LastRowHeight
        {
            get { return _lastRowHeight; }
            set
            {
                _lastRowHeight = value;
                OnPropertyChanged("LastRowHeight");
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

        private int _columnRange { get; set; }

        public int ColumnRange
        {
            get { return _columnRange; }
            set
            {
                _columnRange = value;
                OnPropertyChanged("ColumnRange");
            }
        }

        private int _columnPosition { get; set; }

        public int ColumnPosition
        {
            get { return _columnPosition; }
            set
            {
                _columnPosition = value;
                OnPropertyChanged("ColumnPosition");
            }
        }

        private int _rowPosition { get; set; }

        public int RowPosition
        {
            get { return _rowPosition; }
            set
            {
                _rowPosition = value;
                OnPropertyChanged("RowPosition");
            }
        }

        private string _firstColumnWidth { get; set; }

        public string FirstColumnWidth
        {
            get { return _firstColumnWidth; }
            set
            {
                _firstColumnWidth = value;
                OnPropertyChanged("FirstColumnWidth");
            }
        }

        private RelayCommand _exit { get; set; }

        public RelayCommand Exit
        {
            get
            {
                return _exit ??
                    (_exit = new RelayCommand(x =>
                    {
                        CybersportAppNavigation.CurrentUser = null;

                        CybersportAppNavigation.Service.Navigate(CybersportAppNavigation.CurrentGreetingPage);
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowVM()
        {
            ColumnRange = 2;
            ColumnPosition = 0;
            FirstColumnWidth = "0";

            RowHeight = LastRowHeight = "0";
        }

        public MainWindowVM(int userCode)
        {
            if (userCode != 2)
            {
                RowHeight = "1*";
                LastRowHeight = "0*";
            }
            else
                RowHeight = LastRowHeight = "1*";

            BackgroundImage = new BitmapImage();

            using (MemoryStream memory = new MemoryStream())
            {
                Properties.Resources.abstract_gradient_pink_purple_stripes_on_purple_background.Save(memory, ImageFormat.Jpeg);
                memory.Position = 0;
                BackgroundImage.BeginInit();
                BackgroundImage.StreamSource = memory;
                BackgroundImage.CacheOption = BitmapCacheOption.OnLoad;
                BackgroundImage.EndInit();
            }

            FirstColumnWidth = "1*";
            ColumnRange = 1;
            ColumnPosition = 3;
            RowPosition = 6;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}

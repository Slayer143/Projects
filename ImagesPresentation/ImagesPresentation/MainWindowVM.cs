using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImagesPresentation
{
    public class MainWindowVM : INotifyPropertyChanged
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

        public MainWindowVM()
        {
            BackgroundImage = new BitmapImage();

            using (MemoryStream memory = new MemoryStream())
            {
                Properties.Resources.YioRubacmLc.Save(memory, ImageFormat.Jpeg);
                memory.Position = 0;
                BackgroundImage.BeginInit();
                BackgroundImage.StreamSource = memory;
                BackgroundImage.CacheOption = BitmapCacheOption.OnLoad;
                BackgroundImage.EndInit();
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

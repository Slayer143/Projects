using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace CybersportApp.Pages
{
    /// <summary>
    /// Interaction logic for GreetingPage.xaml
    /// </summary>
    public partial class GreetingPage : Page
    {
        private DoubleAnimation _fromZeroForImages = new DoubleAnimation();

        private DoubleAnimation _fromZero = new DoubleAnimation();

        private DoubleAnimation _toZeroForImages = new DoubleAnimation();

        private BitmapImage _firstImage = new BitmapImage();

        private BitmapImage _secondImage = new BitmapImage();

        private BitmapImage _thirdImage = new BitmapImage();

        private BitmapImage _background = new BitmapImage();

        private BitmapImage[] _images = new BitmapImage[3];

        private int _imageCounter = 0;

        public GreetingPage()
        {
            InitializeComponent();

            DataContext = new GreetingPageVM();

            LoadImages();

            LoadAnimations();

            _myBrush.ImageSource = _images[_imageCounter];
            _myCanvas.BeginAnimation(OpacityProperty, _fromZeroForImages);
        }

        private void ToZeroCompleted(object sender, EventArgs e)
        {
            if (_imageCounter < 2)
            {
                _imageCounter++;

                if (_imageCounter < 3)
                {
                    _myBrush.ImageSource = _images[_imageCounter];
                    _myCanvas.BeginAnimation(OpacityProperty, _fromZeroForImages);
                }

                if (_imageCounter == 2)
                {
                    _greetingBlock.BeginAnimation(OpacityProperty, _fromZero);
                }
            }

            else
            {
                _toZeroForImages.Completed -= ToZeroCompleted;
                _fromZeroForImages.Completed -= FromZeroCompleted;

                _myBrush.ImageSource = _background;
                _myCanvas.BeginAnimation(OpacityProperty, _fromZeroForImages);

                UnlockButtons();
            }
        }

        private void FromZeroCompleted(object sender, EventArgs e)
        {
            _myCanvas.BeginAnimation(OpacityProperty, _toZeroForImages);

            if (_imageCounter == 2)
            {
                _actionBlock.BeginAnimation(OpacityProperty, _fromZero);
                _contactBlock.BeginAnimation(OpacityProperty, _fromZero);
                _registerButton.BeginAnimation(OpacityProperty, _fromZero);
                _authorizeButton.BeginAnimation(OpacityProperty, _fromZero);
            }
        }

        private void UnlockButtons()
        {
            _registerButton.IsEnabled = _authorizeButton.IsEnabled = true;
        }

        private void LoadAnimations()
        {
            _fromZeroForImages.From = 0.0;
            _fromZeroForImages.To = 1.0;
            _fromZeroForImages.Duration = new Duration(TimeSpan.FromSeconds(2.5));

            _fromZero = _fromZeroForImages;

            _toZeroForImages.From = 1.0;
            _toZeroForImages.To = 0.0;
            _toZeroForImages.Duration = new Duration(TimeSpan.FromSeconds(2.5));

            _toZeroForImages.Completed += ToZeroCompleted;
            _fromZeroForImages.Completed += FromZeroCompleted;
        }

        private void LoadImages()
        {
            using (MemoryStream memory = new MemoryStream())
            {
                Properties.Resources._33aaf10c169e5d36_1920xH.Save(memory, ImageFormat.Jpeg);
                memory.Position = 0;
                _firstImage.BeginInit();
                _firstImage.StreamSource = memory;
                _firstImage.CacheOption = BitmapCacheOption.OnLoad;
                _firstImage.EndInit();
            }

            using (MemoryStream memory = new MemoryStream())
            {
                Properties.Resources.e898cbfa782239a43bd96e7f6453.Save(memory, ImageFormat.Jpeg);
                memory.Position = 0;
                _secondImage.BeginInit();
                _secondImage.StreamSource = memory;
                _secondImage.CacheOption = BitmapCacheOption.OnLoad;
                _secondImage.EndInit();
            }

            using (MemoryStream memory = new MemoryStream())
            {
                Properties.Resources.league_of_legends3.Save(memory, ImageFormat.Jpeg);
                memory.Position = 0;
                _thirdImage.BeginInit();
                _thirdImage.StreamSource = memory;
                _thirdImage.CacheOption = BitmapCacheOption.OnLoad;
                _thirdImage.EndInit();
            }

            using (MemoryStream memory = new MemoryStream())
            {
                Properties.Resources.abstract_gradient_pink_purple_stripes_on_purple_background.Save(memory, ImageFormat.Jpeg);
                memory.Position = 0;
                _background.BeginInit();
                _background.StreamSource = memory;
                _background.CacheOption = BitmapCacheOption.OnLoad;
                _background.EndInit();
            }

            _images[0] = _firstImage;
            _images[1] = _secondImage;
            _images[2] = _thirdImage;
        }
    }
}

using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Microsoft.Win32;

namespace WSMarathon.Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DateTimeOffset dateTime = DateTimeOffset.Now;
        private TextBlock _bottomSectionTextBlock { get; set; }
        private TextBlock _topSectionTextBlockOne { get; set; }
        private TextBlock _topSectionTextBlockTwo { get; set; }
        private Button _topSectionBackButton { get; set; }
        private Canvas _topSectionCanvas { get; set; }
        private Canvas _centralSectionCanvas { get; set; }
        private Button _centralSectionRunnerButton { get; set; }
        private Button _centralSectionSponsorButton { get; set; }
        private Button _centralSectionInfoButton { get; set; }
        private Button _centralSectionNotNewButton { get; set; }
        private Button _centralSectionNewButton { get; set; }
        private TextBlock _centralSectionAutorisationFormTextBlock { get; set; }
        private TextBlock _centralSectionAutorisationFormInfoTextBlock { get; set; }
        private TextBlock _centralSectionEmailTextBlock { get; set; }
        private TextBlock _centralSectionPasswordTextBlock { get; set; }
        private TextBlock _centralSectionPasswordRepeatTextBlock { get; set; }
        private TextBlock _centralSectionNameTextBlock { get; set; }
        private TextBlock _centralSectionLastNameTextBlock { get; set; }
        private TextBlock _centralSectionGenderTextBlock { get; set; }
        private TextBlock _centralSectionPhotoTextBlock { get; set; }
        private TextBlock _centralSectionDateOfBirthTextBlock { get; set; }
        private TextBlock _centralSectionCountryTextBlock { get; set; }
        private TextBox _centralSectionDateOfBirthTextBox { get; set; }
        private ComboBox _centralSectionCountryComboBox { get; set; }
        private TextBox _centralSectionEmailTextBox { get; set; }
        private TextBox _centralSectionPasswordTextBox { get; set; }
        private TextBox _centralSectionPasswordRepeatTextBox { get; set; }
        private TextBox _centralSectionNameTextBox { get; set; }
        private TextBox _centralSectionLastNameTextBox { get; set; }
        private TextBox _centralSectionPhotoTextBox { get; set; }
        private ComboBox _centralSectionGenderComboBox { get; set; }
        private Button _centralSectionLoginButton { get; set; }
        private Button _centralSectionLookButton { get; set; }
        private Image _centralSectionPhotoImage { get; set; }
        private DatePicker _centralSectionDatePicker { get; set; }
        private Button _centralSectionRegisterButton { get; set; }
        private CheckBox _centralSectionCheckBoxOne { get; set; }
        private CheckBox _centralSectionCheckBoxTwo { get; set; }
        private CheckBox _centralSectionCheckBoxThree { get; set; }
        private Rectangle _centralSectionPhotoRectangle { get; set; }
        private Canvas _bottomSectionCanvas { get; set; }
        private DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            MainPage.WindowState = WindowState.Maximized;
            MainPage.ResizeMode = ResizeMode.NoResize;

            MainPage.Activate();

            CreateMainDetails();
        }

        public void Refresh(object o, EventArgs e)
        {
            dateTime = DateTimeOffset.Now;

            _bottomSectionTextBlock.Text = $" {(DateTimeOffset.Parse("2019-11-24") - dateTime).Days} дней " +
                            $"{(DateTimeOffset.Parse("2019 - 11 - 24") - dateTime).Hours} часов и " +
                            $"{(DateTimeOffset.Parse("2019 - 11 - 24") - dateTime).Minutes} минут до старта марафона!";
        }

        public void StartTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(Refresh);
            timer.Start();
        }

        public void CreateMainDetails()
        {
            MainPage.WindowState = WindowState.Maximized;
            MainPage.ResizeMode = ResizeMode.NoResize;
            MainPage.Title = "Marathon Skills 2016";

            _topSectionCanvas = new Canvas
            {
                Margin = new Thickness(0, 0, -0.4, 0),
                Height = 250,
                Width = MainPage.Width * 2,
                Background = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };

            _topSectionTextBlockOne = new TextBlock
            {
                Margin = _topSectionCanvas.Margin,
                Height = 50,
                Width = 600,
                Background = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Semibold"),
                FontSize = 40,
                Foreground = Brushes.White,
                Text = "MARATHON SKILLS 2019"
            };

            _topSectionTextBlockTwo = new TextBlock
            {
                Margin = _topSectionCanvas.Margin,
                Height = 100,
                Width = 400,
                Background = Brushes.Black,
                Foreground = Brushes.LightGray,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                FontStyle = FontStyles.Oblique,
                Text = "Москва, Россия\n" +
                       $"{CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dateTime.DayOfWeek)} " +
                       $"{dateTime.Day} " +
                       $"{(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month)).ToLowerInvariant()} " +
                       $"{dateTime.Year}"

            };

            _topSectionCanvas.Children.Add(_topSectionTextBlockOne);
            Canvas.SetLeft(_topSectionTextBlockOne, 475);
            Canvas.SetTop(_topSectionTextBlockOne, 30);

            _topSectionCanvas.Children.Add(_topSectionTextBlockTwo);
            Canvas.SetLeft(_topSectionTextBlockTwo, 575);
            Canvas.SetTop(_topSectionTextBlockTwo, 120);

            _centralSectionCanvas = new Canvas
            {
                Margin = new Thickness(0, 250, -0.4, 0),
                Height = 530,
                Width = MainPage.Width * 2,
                Background = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };

            _centralSectionRunnerButton = new Button
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 100,
                Width = 400,
                Background = Brushes.LightGray,
                Foreground = Brushes.Black,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Content = "Я хочу стать бегуном",
            };

            _centralSectionRunnerButton.Click += SentralSectionRunnerButton_Click;

            _centralSectionSponsorButton = new Button
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 100,
                Width = 400,
                Background = Brushes.LightGray,
                Foreground = Brushes.Black,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Content = "Я хочу стать спонсором бегуна"
            };

            _centralSectionInfoButton = new Button
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 100,
                Width = 400,
                Background = Brushes.LightGray,
                Foreground = Brushes.Black,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Content = "Я хочу узнать больше о событии"
            };

            _centralSectionCanvas.Children.Add(_centralSectionRunnerButton);
            Canvas.SetLeft(_centralSectionRunnerButton, 575);
            Canvas.SetTop(_centralSectionRunnerButton, -220);

            _centralSectionCanvas.Children.Add(_centralSectionSponsorButton);
            Canvas.SetLeft(_centralSectionSponsorButton, 575);
            Canvas.SetTop(_centralSectionSponsorButton, -70);

            _centralSectionCanvas.Children.Add(_centralSectionInfoButton);
            Canvas.SetLeft(_centralSectionInfoButton, 575);
            Canvas.SetTop(_centralSectionInfoButton, 80);

            _bottomSectionCanvas = new Canvas
            {
                Margin = new Thickness(0, 800, 0.4, 0),
                Height = 50,
                Width = MainPage.Width * 2,
                Background = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };

            _bottomSectionTextBlock = new TextBlock
            {
                RenderTransformOrigin = _bottomSectionCanvas.RenderTransformOrigin,
                Height = _bottomSectionCanvas.Height,
                Width = 600,
                Background = Brushes.Black,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                Text = $" {(DateTimeOffset.Parse("2019-11-24") - dateTime).Days} дней " +
                       $"{(DateTimeOffset.Parse("2019 - 11 - 24") - dateTime).Hours} часов и " +
                       $"{(DateTimeOffset.Parse("2019 - 11 - 24") - dateTime).Minutes} минут до старта марафона!"
            };

            _bottomSectionCanvas.Children.Add(_bottomSectionTextBlock);
            Canvas.SetLeft(_bottomSectionTextBlock, 470);
            Canvas.SetTop(_bottomSectionTextBlock, 0);

            MyGrid.Children.Add(_topSectionCanvas);
            MyGrid.Children.Add(_centralSectionCanvas);
            MyGrid.Children.Add(_bottomSectionCanvas);

            StartTimer();
        }

        private void CreateRunnerMainMenuDetails()
        {
            MyGrid.Children.Clear();
            MainPage.Title = "Marathon Skills 2016 - Register as a runner";

            _topSectionCanvas.Children.Clear();
            _topSectionCanvas.Height = 100;

            _topSectionCanvas.Children.Add(_topSectionTextBlockOne);
            Canvas.SetLeft(_topSectionTextBlockOne, 100);
            Canvas.SetTop(_topSectionTextBlockOne, 20);

            _topSectionBackButton = new Button
            {
                Margin = _topSectionCanvas.Margin,
                Height = 50,
                Width = 100,
                Background = Brushes.LightGray,
                Foreground = Brushes.Black,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Content = "Назад"
            };

            _topSectionBackButton.Click += TopSectionBackToMainButton_Click;

            _topSectionCanvas.Children.Add(_topSectionBackButton);
            Canvas.SetLeft(_topSectionBackButton, 25);
            Canvas.SetTop(_topSectionBackButton, 20);

            MyGrid.Children.Add(_topSectionCanvas);

            _centralSectionCanvas.Height = 655;
            _centralSectionCanvas.Margin = new Thickness(0, 100, -0.4, 0);
            _centralSectionCanvas.Children.Clear();

            _centralSectionNotNewButton = new Button
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 100,
                Width = 400,
                Background = Brushes.LightGray,
                Foreground = Brushes.Black,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontStyle = FontStyles.Italic,
                Content = "Я уже участвовал ранее"
            };

            _centralSectionNewButton = new Button
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 100,
                Width = 400,
                Background = Brushes.LightGray,
                Foreground = Brushes.Black,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontStyle = FontStyles.Italic,
                Content = "Я новый участник"
            };

            _centralSectionNewButton.Click += RunnerRegistrationButton_Click;
            _centralSectionNotNewButton.Click += AuthorizationButton_Click;

            _centralSectionCanvas.Children.Add(_centralSectionNewButton);
            Canvas.SetLeft(_centralSectionNewButton, 575);
            Canvas.SetTop(_centralSectionNewButton, 25);

            _centralSectionCanvas.Children.Add(_centralSectionNotNewButton);
            Canvas.SetLeft(_centralSectionNotNewButton, 575);
            Canvas.SetTop(_centralSectionNotNewButton, 225);

            MyGrid.Children.Add(_centralSectionCanvas);
            MyGrid.Children.Add(_bottomSectionCanvas);
        }

        private void CreateAutorizationMenu()
        {
            MyGrid.Children.Clear();
            MyGrid.Children.Add(_topSectionCanvas);
            MyGrid.Children.Add(_bottomSectionCanvas);
            _centralSectionCanvas.Children.Clear();

            _topSectionBackButton.Click -= TopSectionBackToMainButton_Click;
            _topSectionBackButton.Click += TopSectionBackToRunnerButton_Click;

            _centralSectionAutorisationFormTextBlock = new TextBlock
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 50,
                Width = 400,
                Background = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Semibold"),
                FontSize = 40,
                Foreground = Brushes.Black,
                Text = "Форма авторизации"
            };

            _centralSectionAutorisationFormInfoTextBlock = new TextBlock
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 50,
                Width = 600,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                Text = "Пожалуйста, авторизуйтесь в системе, используя ваш адрес электронной почты и пароль"
            };

            _centralSectionEmailTextBlock = new TextBlock
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 50,
                Width = 75,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                Text = "Email:"
            };

            _centralSectionPasswordTextBlock = new TextBlock
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 50,
                Width = 100,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                Text = "Password:"
            };

            _centralSectionEmailTextBox = new TextBox
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 35,
                Width = 300,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                FontStyle = FontStyles.Italic,
                TextWrapping = TextWrapping.NoWrap,
                Text = "Enter your email adress",
                BorderBrush = Brushes.Black,
                MaxLength = 50
            };

            _centralSectionPasswordTextBox = new TextBox
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 35,
                Width = 300,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                FontStyle = FontStyles.Italic,
                TextWrapping = TextWrapping.NoWrap,
                Text = "Enter your password",
                BorderBrush = Brushes.Black,
                MaxLength = 50
            };

            _centralSectionLoginButton = new Button
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 50,
                Width = 100,
                Background = Brushes.LightGray,
                Foreground = Brushes.Black,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Content = "Login"
            };

            _centralSectionEmailTextBox.GotFocus += EmailTextBoxGotFocus;
            _centralSectionPasswordTextBox.GotFocus += PasswordTextBoxGotFocus;

            _centralSectionCanvas.Children.Add(_centralSectionAutorisationFormTextBlock);
            Canvas.SetLeft(_centralSectionAutorisationFormTextBlock, 575);
            Canvas.SetBottom(_centralSectionAutorisationFormTextBlock, 575);

            _centralSectionCanvas.Children.Add(_centralSectionAutorisationFormInfoTextBlock);
            Canvas.SetLeft(_centralSectionAutorisationFormInfoTextBlock, 475);
            Canvas.SetBottom(_centralSectionAutorisationFormInfoTextBlock, 500);

            _centralSectionCanvas.Children.Add(_centralSectionEmailTextBlock);
            Canvas.SetLeft(_centralSectionEmailTextBlock, 525);
            Canvas.SetBottom(_centralSectionEmailTextBlock, 375);

            _centralSectionCanvas.Children.Add(_centralSectionPasswordTextBlock);
            Canvas.SetLeft(_centralSectionPasswordTextBlock, 493);
            Canvas.SetBottom(_centralSectionPasswordTextBlock, 300);

            _centralSectionCanvas.Children.Add(_centralSectionEmailTextBox);
            Canvas.SetLeft(_centralSectionEmailTextBox, 625);
            Canvas.SetBottom(_centralSectionEmailTextBox, 390);

            _centralSectionCanvas.Children.Add(_centralSectionPasswordTextBox);
            Canvas.SetLeft(_centralSectionPasswordTextBox, 625);
            Canvas.SetBottom(_centralSectionPasswordTextBox, 315);

            _centralSectionCanvas.Children.Add(_centralSectionLoginButton);
            Canvas.SetLeft(_centralSectionLoginButton, 625);
            Canvas.SetBottom(_centralSectionLoginButton, 240);

            MyGrid.Children.Add(_centralSectionCanvas);
        }

        private void CreateRunnerRegistrationMenu()
        {
            MyGrid.Children.Clear();

            _centralSectionCanvas.Children.Clear();

            MyGrid.Children.Add(_topSectionCanvas);

            _centralSectionAutorisationFormTextBlock = new TextBlock
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 50,
                Width = 400,
                Background = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Semibold"),
                FontSize = 40,
                Foreground = Brushes.Black,
                Text = "Регистрация бегуна"
            };

            _centralSectionAutorisationFormInfoTextBlock = new TextBlock
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 75,
                Width = 700,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                Text = "Пожалуйста заполните всю информацию, чтобы зарегистрироваться в качестве бегуна"
            };

            _centralSectionEmailTextBlock = new TextBlock
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 50,
                Width = 75,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                Text = "Email:"
            };

            _centralSectionPasswordTextBlock = new TextBlock
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 50,
                Width = 100,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                Text = "Пароль:"
            };

            _centralSectionPasswordRepeatTextBlock = new TextBlock
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 50,
                Width = 200,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                Text = "Повторите пароль:"
            };

            _centralSectionNameTextBlock = new TextBlock
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 50,
                Width = 100,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                Text = "Имя:"
            };

            _centralSectionLastNameTextBlock = new TextBlock
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 50,
                Width = 100,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                Text = "Фамилия:"
            };

            _centralSectionGenderTextBlock = new TextBlock
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 50,
                Width = 100,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                Text = "Пол:"
            };

            _centralSectionPhotoTextBlock = new TextBlock
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 50,
                Width = 175,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                Text = "Фото файл:"
            };

            _centralSectionEmailTextBox = new TextBox
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 35,
                Width = 300,
                Background = Brushes.White,
                Foreground = Brushes.Gray,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Left,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                FontStyle = FontStyles.Italic,
                TextWrapping = TextWrapping.NoWrap,
                Text = "Email",
                BorderBrush = Brushes.Black,
                MaxLength = 50
            };

            _centralSectionEmailTextBox.GotFocus += EmailFocused;

            _centralSectionPasswordTextBox = new TextBox
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 35,
                Width = 300,
                Background = Brushes.White,
                Foreground = Brushes.Gray,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Left,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                FontStyle = FontStyles.Italic,
                TextWrapping = TextWrapping.NoWrap,
                Text = "Пароль",
                BorderBrush = Brushes.Black,
                MaxLength = 50
            };

            _centralSectionPasswordTextBox.GotFocus += PasswordFocused;

            _centralSectionPasswordRepeatTextBox = new TextBox
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 35,
                Width = 300,
                Background = Brushes.White,
                Foreground = Brushes.Gray,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Left,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                FontStyle = FontStyles.Italic,
                TextWrapping = TextWrapping.NoWrap,
                Text = "Повторите пароль",
                BorderBrush = Brushes.Black,
                MaxLength = 50
            };

            _centralSectionPasswordRepeatTextBox.GotFocus += PasswordRepeatFocused;

            _centralSectionNameTextBox = new TextBox
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 35,
                Width = 300,
                Background = Brushes.White,
                Foreground = Brushes.Gray,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Left,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                FontStyle = FontStyles.Italic,
                TextWrapping = TextWrapping.NoWrap,
                Text = "Имя",
                BorderBrush = Brushes.Black,
                MaxLength = 50
            };

            _centralSectionNameTextBox.GotFocus += NameFocused;

            _centralSectionLastNameTextBox = new TextBox
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 35,
                Width = 300,
                Background = Brushes.White,
                Foreground = Brushes.Gray,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Left,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                FontStyle = FontStyles.Italic,
                TextWrapping = TextWrapping.NoWrap,
                Text = "Фамилия",
                BorderBrush = Brushes.Black,
                MaxLength = 50
            };

            _centralSectionLastNameTextBox.GotFocus += LastNameFocused;

            _centralSectionPhotoRectangle = new Rectangle
            {
                Margin = new Thickness(630, 80, 0, 0),
                Height = 200,
                Width = 150,
                Fill = Brushes.LightGray
            };

            _centralSectionPhotoTextBox = new TextBox
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 35,
                Width = 300,
                Background = Brushes.White,
                Foreground = Brushes.Gray,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Left,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                FontStyle = FontStyles.Italic,
                TextWrapping = TextWrapping.NoWrap,
                Text = "Photo.jpg",
                BorderBrush = Brushes.Black,
                MaxLength = 50,
                IsReadOnly = true
            };

            _centralSectionGenderComboBox = new ComboBox
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 35,
                Width = 300,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                FontStyle = FontStyles.Italic,
                IsEditable = false,
                BorderBrush = Brushes.Black,
            };

            _centralSectionLookButton = new Button
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 35,
                Width = 150,
                Background = Brushes.LightGray,
                Foreground = Brushes.Black,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Content = "Просмотр"
            };

            _centralSectionPhotoImage = new Image
            {
                Margin = _centralSectionPhotoRectangle.Margin,
                Height = _centralSectionPhotoRectangle.Height,
                Width = _centralSectionPhotoRectangle.Width,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Stretch = Stretch.Fill
            };

            _centralSectionDateOfBirthTextBlock = new TextBlock
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 50,
                Width = 175,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                Text = " Дата рождения:"
            };

            _centralSectionCountryTextBlock = new TextBlock
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 50,
                Width = 175,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                Text = "Страна:"
            };

            _centralSectionDateOfBirthTextBox = new TextBox
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 35,
                Width = 300,
                Background = Brushes.White,
                Foreground = Brushes.Gray,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                TextAlignment = TextAlignment.Left,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                FontStyle = FontStyles.Italic,
                TextWrapping = TextWrapping.NoWrap,
                Text = "Date",
                BorderBrush = Brushes.Black,
                MaxLength = 50,
                IsReadOnly = true
            };

            _centralSectionDateOfBirthTextBox.GotFocus += DateOfBirthFocused;

            _centralSectionCountryComboBox = new ComboBox
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 35,
                Width = 300,
                Background = Brushes.White,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                IsEditable = false,
                FontStyle = FontStyles.Italic,
                BorderBrush = Brushes.Black,
            };

            _centralSectionDatePicker = new DatePicker
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 30,
                Width = 30
            };

            _centralSectionDatePicker.SelectedDateChanged += DatePicked;

            _centralSectionRegisterButton = new Button
            {
                Margin = _centralSectionCanvas.Margin,
                Height = 35,
                Width = 300,
                Background = Brushes.LightGray,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                FontFamily = new FontFamily("Open Sans Light"),
                FontSize = 20,
                FontStyle = FontStyles.Italic,
                Content = "Зарегистрироваться",
                BorderBrush = Brushes.Black,
            };

            _centralSectionRegisterButton.Click += RegisterButton_Click;

            using (var context = new WSMarathonRepository())
            {
                var countries = context.Country.ToList();

                foreach (var country in countries)
                {
                    _centralSectionCountryComboBox.Items.Add(country.CountryName);
                }

                var genders = context.Gender.ToList();

                foreach (var gender in genders)
                {
                    _centralSectionGenderComboBox.Items.Add(gender.Gender);
                }
            }

            _centralSectionCanvas.Children.Add(_centralSectionPhotoRectangle);
            Canvas.SetLeft(_centralSectionPhotoRectangle, 645);
            Canvas.SetBottom(_centralSectionPhotoRectangle, 275);

            _centralSectionCanvas.Children.Add(_centralSectionPhotoImage);
            Canvas.SetLeft(_centralSectionPhotoImage, 645);
            Canvas.SetBottom(_centralSectionPhotoImage, 275);

            _centralSectionCanvas.Children.Add(_centralSectionAutorisationFormTextBlock);
            Canvas.SetLeft(_centralSectionAutorisationFormTextBlock, 575);
            Canvas.SetBottom(_centralSectionAutorisationFormTextBlock, 575);

            _centralSectionCanvas.Children.Add(_centralSectionAutorisationFormInfoTextBlock);
            Canvas.SetLeft(_centralSectionAutorisationFormInfoTextBlock, 425);
            Canvas.SetBottom(_centralSectionAutorisationFormInfoTextBlock, 500);

            _centralSectionCanvas.Children.Add(_centralSectionEmailTextBlock);
            Canvas.SetLeft(_centralSectionEmailTextBlock, 425);
            Canvas.SetBottom(_centralSectionEmailTextBlock, 400);

            _centralSectionCanvas.Children.Add(_centralSectionPasswordTextBlock);
            Canvas.SetLeft(_centralSectionPasswordTextBlock, 402);
            Canvas.SetBottom(_centralSectionPasswordTextBlock, 350);

            _centralSectionCanvas.Children.Add(_centralSectionPasswordRepeatTextBlock);
            Canvas.SetLeft(_centralSectionPasswordRepeatTextBlock, 298);
            Canvas.SetBottom(_centralSectionPasswordRepeatTextBlock, 300);

            _centralSectionCanvas.Children.Add(_centralSectionNameTextBlock);
            Canvas.SetLeft(_centralSectionNameTextBlock, 418);
            Canvas.SetBottom(_centralSectionNameTextBlock, 250);

            _centralSectionCanvas.Children.Add(_centralSectionLastNameTextBlock);
            Canvas.SetLeft(_centralSectionLastNameTextBlock, 393);
            Canvas.SetBottom(_centralSectionLastNameTextBlock, 200);

            _centralSectionCanvas.Children.Add(_centralSectionGenderTextBlock);
            Canvas.SetLeft(_centralSectionGenderTextBlock, 418);
            Canvas.SetBottom(_centralSectionGenderTextBlock, 150);

            _centralSectionCanvas.Children.Add(_centralSectionPhotoTextBlock);
            Canvas.SetLeft(_centralSectionPhotoTextBlock, 918);
            Canvas.SetBottom(_centralSectionPhotoTextBlock, 250);

            _centralSectionCanvas.Children.Add(_centralSectionDateOfBirthTextBlock);
            Canvas.SetLeft(_centralSectionDateOfBirthTextBlock, 898);
            Canvas.SetBottom(_centralSectionDateOfBirthTextBlock, 150);

            _centralSectionCanvas.Children.Add(_centralSectionCountryTextBlock);
            Canvas.SetLeft(_centralSectionCountryTextBlock, 938);
            Canvas.SetBottom(_centralSectionCountryTextBlock, 100);

            _centralSectionCanvas.Children.Add(_centralSectionEmailTextBox);
            Canvas.SetLeft(_centralSectionEmailTextBox, 520);
            Canvas.SetBottom(_centralSectionEmailTextBox, 415);

            _centralSectionCanvas.Children.Add(_centralSectionPasswordTextBox);
            Canvas.SetLeft(_centralSectionPasswordTextBox, 520);
            Canvas.SetBottom(_centralSectionPasswordTextBox, 365);

            _centralSectionCanvas.Children.Add(_centralSectionPasswordRepeatTextBox);
            Canvas.SetLeft(_centralSectionPasswordRepeatTextBox, 520);
            Canvas.SetBottom(_centralSectionPasswordRepeatTextBox, 315);

            _centralSectionCanvas.Children.Add(_centralSectionNameTextBox);
            Canvas.SetLeft(_centralSectionNameTextBox, 520);
            Canvas.SetBottom(_centralSectionNameTextBox, 265);

            _centralSectionCanvas.Children.Add(_centralSectionLastNameTextBox);
            Canvas.SetLeft(_centralSectionLastNameTextBox, 520);
            Canvas.SetBottom(_centralSectionLastNameTextBox, 215);

            _centralSectionCanvas.Children.Add(_centralSectionGenderComboBox);
            Canvas.SetLeft(_centralSectionGenderComboBox, 520);
            Canvas.SetBottom(_centralSectionGenderComboBox, 165);

            _centralSectionCanvas.Children.Add(_centralSectionCountryComboBox);
            Canvas.SetLeft(_centralSectionCountryComboBox, 1098);
            Canvas.SetBottom(_centralSectionCountryComboBox, 115);

            _centralSectionCanvas.Children.Add(_centralSectionDateOfBirthTextBox);
            Canvas.SetLeft(_centralSectionDateOfBirthTextBox, 1098);
            Canvas.SetBottom(_centralSectionDateOfBirthTextBox, 165);

            _centralSectionCanvas.Children.Add(_centralSectionDatePicker);
            Canvas.SetLeft(_centralSectionDatePicker, 1398);
            Canvas.SetBottom(_centralSectionDatePicker, 165);

            _centralSectionCanvas.Children.Add(_centralSectionPhotoTextBox);
            Canvas.SetLeft(_centralSectionPhotoTextBox, 918);
            Canvas.SetBottom(_centralSectionPhotoTextBox, 230);

            _centralSectionCanvas.Children.Add(_centralSectionLookButton);
            Canvas.SetLeft(_centralSectionLookButton, 1275);
            Canvas.SetBottom(_centralSectionLookButton, 230);

            _centralSectionCanvas.Children.Add(_centralSectionRegisterButton);
            Canvas.SetLeft(_centralSectionRegisterButton, 650);
            Canvas.SetBottom(_centralSectionRegisterButton, 0);

            _topSectionBackButton.Click -= TopSectionBackToMainButton_Click;
            _topSectionBackButton.Click += TopSectionBackToRunnerButton_Click;
            _centralSectionLookButton.Click += LookButton_Click;

            MyGrid.Children.Add(_centralSectionCanvas);
            MyGrid.Children.Add(_bottomSectionCanvas);
        }

        private void DateOfBirthFocused(object sender, RoutedEventArgs e)
        {
            _centralSectionDateOfBirthTextBox.Text = "";
            _centralSectionDateOfBirthTextBox.GotFocus -= DateOfBirthFocused;
        }

        private void LastNameFocused(object sender, RoutedEventArgs e)
        {
            _centralSectionLastNameTextBox.Text = "";
            _centralSectionLastNameTextBox.GotFocus -= LastNameFocused;
        }

        private void NameFocused(object sender, RoutedEventArgs e)
        {
            _centralSectionNameTextBox.Text = "";
            _centralSectionNameTextBox.GotFocus -= NameFocused;
        }

        private void PasswordFocused(object sender, RoutedEventArgs e)
        {
            _centralSectionPasswordTextBox.Text = "";
            _centralSectionPasswordTextBox.GotFocus -= PasswordFocused;
        }

        private void PasswordRepeatFocused(object sender, RoutedEventArgs e)
        {
            _centralSectionPasswordRepeatTextBox.Text = "";
            _centralSectionPasswordRepeatTextBox.GotFocus -= PasswordRepeatFocused;
        }

        private void EmailFocused(object sender, RoutedEventArgs e)
        {
            _centralSectionEmailTextBox.Text = "";
            _centralSectionEmailTextBox.GotFocus -= EmailFocused;
        }

        public void CreateMarathonRegisterMenu()
        {
            MyGrid.Children.Clear();
            MyGrid.Children.Add(_topSectionCanvas);
            MyGrid.Children.Add(_bottomSectionCanvas);

            _centralSectionCanvas.Children.Clear();

            _topSectionBackButton.Click -= TopSectionBackToRunnerButton_Click;
            _topSectionBackButton.Click += TopSectionBackToRunnerRegistrationButton_Click;

            MyGrid.Children.Add(_centralSectionCanvas);
        }

        private void TopSectionBackToRunnerRegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.Children.Clear();
            _centralSectionCanvas.Children.Clear();
            CreateRunnerRegistrationMenu();
        }
        private void DatePicked(object sender, RoutedEventArgs e)
        {
            _centralSectionDateOfBirthTextBox.Text = _centralSectionDatePicker.SelectedDate.Value.ToShortDateString();
        }

        private void LookButton_Click(object sender, RoutedEventArgs e)
        {
            var fileInfo = new OpenFileDialog();

            if (fileInfo.ShowDialog() == true)
            {
                _centralSectionPhotoTextBox.Text = fileInfo.FileName;
                _centralSectionPhotoImage.Source = (new ImageSourceConverter()).ConvertFromString(fileInfo.FileName) as ImageSource;
            }
        }

        private bool PasswordCheck()
        {
            bool nums = false, letters = false, symbols = false;
            int length = _centralSectionPasswordTextBox.Text.Length;
            string
                numsPattern = "0123456789",
                lettersPattern = "QWERTYUIOPASDFGHJKLZXCVBNM",
                symbolsPattern = "!@#$%^",
                content = _centralSectionPasswordTextBox.Text,
                repeatContent = _centralSectionPasswordRepeatTextBox.Text;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < numsPattern.Length; j++)
                {
                    if (content[i] == numsPattern[j])
                        nums = true;
                }
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < lettersPattern.Length; j++)
                {
                    if (content[i] == lettersPattern[j])
                        letters = true;
                }
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < symbolsPattern.Length; j++)
                {
                    if (content[i] == symbolsPattern[j])
                        symbols = true;
                }
            }

            return length >= 6 && nums
                && letters
                && symbols
                && content == repeatContent;
        }

        private bool EmailCheck()
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            return Regex.IsMatch(_centralSectionEmailTextBox.Text, pattern, RegexOptions.IgnoreCase)
                ? true
                : false;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool
                    email = EmailCheck(),
                    password = PasswordCheck();
                if (email && password)
                {
                    _centralSectionCanvas.Children.Clear();
                    CreateMarathonRegisterMenu();
                }
                else
                if (!email)
                {
                    _centralSectionEmailTextBox.Clear();
                    _centralSectionEmailTextBox.BorderBrush = Brushes.Red;
                }
                if (!password)
                {
                    _centralSectionPasswordTextBox.Clear();
                    _centralSectionPasswordTextBox.BorderBrush = Brushes.Red;
                    _centralSectionPasswordRepeatTextBox.Clear();
                    _centralSectionPasswordRepeatTextBox.BorderBrush = Brushes.Red;
                }
            }
            catch (Exception)
            {
            }
        }

        private void RunnerRegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.Children.Clear();
            _centralSectionCanvas.Children.Clear();
            CreateRunnerRegistrationMenu();
        }

        private void EmailTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            _centralSectionEmailTextBox.Text = string.Empty;
            _centralSectionEmailTextBox.GotFocus -= EmailTextBoxGotFocus;
        }

        private void PasswordTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            _centralSectionPasswordTextBox.Text = string.Empty;
            _centralSectionPasswordTextBox.GotFocus -= PasswordTextBoxGotFocus;
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.Children.Clear();
            _centralSectionCanvas.Children.Clear();
            CreateAutorizationMenu();
        }

        private void TopSectionBackToMainButton_Click(object sender, RoutedEventArgs e)
        {
            _bottomSectionCanvas.Children.Clear();
            _topSectionCanvas.Children.Clear();
            MyGrid.Children.Clear();
            CreateMainDetails();
        }

        private void TopSectionBackToRunnerButton_Click(object sender, RoutedEventArgs e)
        {
            _centralSectionCanvas.Children.Clear();
            MyGrid.Children.Clear();
            CreateRunnerMainMenuDetails();
        }

        private void SentralSectionRunnerButton_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.Children.Clear();
            _centralSectionCanvas.Children.Clear();
            CreateRunnerMainMenuDetails();
        }
    }
}


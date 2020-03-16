using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using Brushes = System.Windows.Media.Brushes;
using Furniture.Domain;

namespace Furniture.Pages
{
    /// <summary>
    /// Interaction logic for Autorisation.xaml
    /// </summary>
    public partial class Autorisation : Page
    {
        private FurnitureDomain domain = new FurnitureDomain();

        public Autorisation()
        {
            InitializeComponent();

            autorise.Loaded += PageOpened;
            pageName.Text = autorise.Title;
        }

        private void PageOpened(object sender, RoutedEventArgs e)
        {
            domain.GenerateCapture(capture);
        }

        public void BackButtonPressed(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartingPage());
        }

        public void LoginBoxFocused(object sender, RoutedEventArgs e)
        {
            domain.ClearTextBox(loginBox);
        }

        public bool CheckEmpty()
        {
            if (passwordBox.Password == string.Empty)
                passwordBox.Background = Brushes.Red;
            else
                passwordBox.Background = Brushes.White;

            if (loginBox.Text == string.Empty
                || loginBox.Text == "Введите логин")
                loginBox.Background = Brushes.Red;
            else
                loginBox.Background = Brushes.White;

            return passwordBox.Password != string.Empty
                && loginBox.Text != string.Empty
                || loginBox.Text != "Введите логин";
        }

        public void NextButtonPressed(object sender, RoutedEventArgs e)
        {
            if (CheckEmpty())
            {
                if (domain.AuthorizeDataCheck(
                passwordBox.Password,
                passwordBox,
                loginBox.Text,
                loginBox,
                capture.Text,
                captureCheck.Text))
                {
                    switch (domain.Role)
                    {
                        case 1:
                            NavigationService.Navigate(new Customer(loginBox.Text));
                            break;
                        case 2:
                            NavigationService.Navigate(new Manager());
                            break;
                        case 3:
                            NavigationService.Navigate(new Master());
                            break;
                        case 4:
                            NavigationService.Navigate(new DeputyDirector());
                            break;
                        case 5:
                            NavigationService.Navigate(new Director());
                            break;
                    }
                }

                else
                {
                    captureCheck.Text = null;
                    domain.GenerateCapture(capture);
                }
            }

            else
            {
                captureCheck.Text = null;
                domain.GenerateCapture(capture);
            }
        }
    }
}

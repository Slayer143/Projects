using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Furniture.Domain;

namespace Furniture.Pages
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public FurnitureDomain domain = new FurnitureDomain();

        public Registration()
        {
            InitializeComponent();

            register.Loaded += PageOpened;
            pageName.Text = register.Title;
        }

        private void PageOpened(object sender, RoutedEventArgs e)
        {
            domain.GenerateCapture(capture);
        }

        public bool CheckEmpty()
        {
            if (loginBox.Text == string.Empty
                || loginBox.Text == "Введите логин")
                loginBox.Background = Brushes.Red;
            else
                loginBox.Background = Brushes.White;

            if (passwordBox.Password == string.Empty)
                passwordBox.Background = Brushes.Red;
            else
                passwordBox.Background = Brushes.White;

            if (passwordBoxRepeat.Password == string.Empty)
                passwordBoxRepeat.Background = Brushes.Red;
            else
                passwordBoxRepeat.Background = Brushes.White;

            return captureCheck.Text == string.Empty
                && loginBox.Text == string.Empty
                || loginBox.Text == "Введите логин"
                && passwordBox.Password == string.Empty
                && passwordBoxRepeat.Password == string.Empty
                ? false
                : true;

        }

        private void NextButtonPressed(object sender, RoutedEventArgs e)
        {
            if (CheckEmpty())
            {
                if (domain.RegistrationDataCheck(
                passwordBox.Password,
                passwordBox,
                passwordBoxRepeat.Password,
                passwordBoxRepeat,
                loginBox.Text,
                loginBox,
                capture.Text,
                captureCheck.Text))
                {
                    if (lastNameBox.Text == "Введите фамилию")
                        lastNameBox.Text = null;

                    if (name.Text == "Введите имя")
                        lastNameBox.Text = null;

                    if (secondNameBox.Text == "Введите отчество")
                        secondNameBox.Text = null;

                    domain.AddUserToTheDatabase(
                        loginBox.Text,
                        passwordBox.Password,
                        1,
                        name.Text,
                        lastNameBox.Text,
                        secondNameBox.Text);

                    NavigationService.Navigate(new Customer(loginBox.Text));
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

        private void BackButtonPressed(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void LoginBoxFocused(object sender, RoutedEventArgs e)
        {
            domain.ClearTextBox(sender as TextBox);
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            domain.OpenImage(profileImage);
        }
    }
}

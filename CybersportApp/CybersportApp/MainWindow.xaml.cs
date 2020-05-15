using CybersportApp.Pages;
using System.Windows;
using System.Windows.Controls;

namespace CybersportApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //CybersportAppNavigation.CurrentGreetingPage = new GreetingPage();
            //baseFrame.Content = CybersportAppNavigation.CurrentGreetingPage;
            //baseFrame.Content = new RegistrationPage();

            baseFrame.Content = new AuthorizationPage();

            DataContext = new MainWindowVM();

            CybersportAppNavigation.CurrentWindow = this;
            CybersportAppNavigation.Service = baseFrame.NavigationService;
        }
    }
}

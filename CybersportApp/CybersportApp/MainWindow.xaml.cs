using CybersportApp.Pages;
using System.Windows;

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

            baseFrame.Content = new GreetingPage();

            CybersportAppNavigation.Service = baseFrame.NavigationService;
        }
    }
}

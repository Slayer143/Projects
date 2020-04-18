using CybersportApplication.Pages;
using System.Windows;

namespace CybersportApplication
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

            CybersportNavigation.Service = baseFrame.NavigationService;
        }
    }
}

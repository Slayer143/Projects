using PavilionsApp.Pages;
using System.Windows;

namespace PavilionsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //_myFrame.Content = new BeginnerPage();
            _myFrame.Content = new ManagerCPage();

            PavilionsNavigation.Service = _myFrame.NavigationService;
        }
    }
}

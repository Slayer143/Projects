using System.Windows.Controls;

namespace PavilionsApp.Pages
{
    /// <summary>
    /// Interaction logic for ManagerCPage.xaml
    /// </summary>
    public partial class ManagerCPage : Page
    {
        public ManagerCPage()
        {
            InitializeComponent();

            DataContext = new ManagerCPageVM();
        }
    }
}

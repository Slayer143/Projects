using System.Windows.Controls;

namespace CybersportApp.Pages
{
    /// <summary>
    /// Interaction logic for TeamsViewPage.xaml
    /// </summary>
    public partial class TeamsViewPage : Page
    {
        public TeamsViewPage()
        {
            InitializeComponent();

            DataContext = new TeamsViewVM();
        }
    }
}

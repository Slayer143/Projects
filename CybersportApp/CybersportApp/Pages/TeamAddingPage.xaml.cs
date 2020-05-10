using System.Windows.Controls;

namespace CybersportApp.Pages
{
    /// <summary>
    /// Interaction logic for TeamAddingPage.xaml
    /// </summary>
    public partial class TeamAddingPage : Page
    {
        public TeamAddingPage()
        {
            InitializeComponent();

            DataContext = new TeamAddingPageVM();
        }
    }
}

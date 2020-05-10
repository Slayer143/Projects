using System.Windows.Controls;

namespace CybersportApp.Pages
{
    /// <summary>
    /// Interaction logic for TournamentAddingPage.xaml
    /// </summary>
    public partial class TournamentAddingPage : Page
    {
        public TournamentAddingPage()
        {
            InitializeComponent();

            DataContext = new TournamentAddingPageVM();
        }
    }
}

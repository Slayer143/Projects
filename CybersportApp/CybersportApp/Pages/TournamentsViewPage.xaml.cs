using System.Windows.Controls;

namespace CybersportApp.Pages
{
    /// <summary>
    /// Interaction logic for TournamentsViewPage.xaml
    /// </summary>
    public partial class TournamentsViewPage : Page
    {
        public TournamentsViewPage()
        {
            InitializeComponent();

            DataContext = new TournamentsViewPageVM();
        }
    }
}

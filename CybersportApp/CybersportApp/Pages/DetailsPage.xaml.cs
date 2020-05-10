using System.Windows.Controls;

namespace CybersportApp.Pages
{
    /// <summary>
    /// Interaction logic for DetailsPage.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        public DetailsPage(string login = null)
        {
            InitializeComponent();

            if (login == null)
                DataContext = new DetailsPageVM();
            else
                DataContext = new DetailsPageVM(login);
        }
    }
}

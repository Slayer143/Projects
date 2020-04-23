using System.Windows.Controls;

namespace CybersportApp.Pages
{
    /// <summary>
    /// Interaction logic for UsersViewPage.xaml
    /// </summary>
    public partial class UsersViewPage : Page
    {
        public UsersViewPage()
        {
            InitializeComponent();

            DataContext = new UsersViewPageVM();
        }
    }
}

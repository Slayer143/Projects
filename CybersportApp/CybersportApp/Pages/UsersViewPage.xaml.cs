using CybersportApp.Core.ModelsForList;
using System.Windows;
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

        private void ShowUser(object sender, RoutedEventArgs e)
        {
            CybersportAppNavigation.Service.Navigate(new ProfileMenu((view.SelectedItem as UsersForList).Login));
        }
    }
}

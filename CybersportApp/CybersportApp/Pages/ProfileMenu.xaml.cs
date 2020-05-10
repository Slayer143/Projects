using System.Windows.Controls;

namespace CybersportApp.Pages
{
    /// <summary>
    /// Interaction logic for ProfileMenu.xaml
    /// </summary>
    public partial class ProfileMenu : Page
    {
        public ProfileMenu(string login = null)
        {
            InitializeComponent();

            if(login == null)
                DataContext = new ProfileMenuVM();
            else
                DataContext = new ProfileMenuVM(login);
        }
    }
}

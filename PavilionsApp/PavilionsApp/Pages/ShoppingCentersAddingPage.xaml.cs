using System.Windows.Controls;

namespace PavilionsApp.Pages
{
    /// <summary>
    /// Interaction logic for ShoppingCentersAddingPage.xaml
    /// </summary>
    public partial class ShoppingCentersAddingPage : Page
    {
        public ShoppingCentersAddingPage()
        {
            InitializeComponent();

            DataContext = new ShoppingCentersAddingPageVM();
        }
    }
}

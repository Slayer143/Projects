using System.Windows;
using System.Windows.Controls;

namespace PavilionsApp.Pages
{
    /// <summary>
    /// Interaction logic for ShoppingCentersPage.xaml
    /// </summary>
    public partial class ShoppingCentersPage : Page
    {
        public ShoppingCentersPage()
        {
            InitializeComponent();

            DataContext = new ShoppingCentersPageVM();
        }
    }
}

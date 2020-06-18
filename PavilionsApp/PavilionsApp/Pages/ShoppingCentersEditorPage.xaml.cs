using System.Windows.Controls;

namespace PavilionsApp.Pages
{
    /// <summary>
    /// Interaction logic for ShoppingCentersEditorPage.xaml
    /// </summary>
    public partial class ShoppingCentersEditorPage : Page
    {
        public ShoppingCentersEditorPage()
        {
            InitializeComponent();

            DataContext = new ShoppingCentersEditorPageVM();
        }
    }
}

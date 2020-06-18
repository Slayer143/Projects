using System.Windows.Controls;

namespace PavilionsApp.Pages
{
    /// <summary>
    /// Interaction logic for PavilionsPage.xaml
    /// </summary>
    public partial class PavilionsPage : Page
    {
        public PavilionsPage()
        {
            InitializeComponent();

            DataContext = new PavilionsPageVM();
        }
    }
}

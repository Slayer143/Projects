using System.Windows.Controls;

namespace PavilionsApp.Pages
{
    /// <summary>
    /// Interaction logic for PavilionsAddingPage.xaml
    /// </summary>
    public partial class PavilionsAddingPage : Page
    {
        public PavilionsAddingPage()
        {
            InitializeComponent();

            DataContext = new PavilionsAddingVM();
        }
    }
}

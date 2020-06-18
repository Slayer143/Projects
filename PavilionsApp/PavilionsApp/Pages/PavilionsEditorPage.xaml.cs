using System.Windows.Controls;

namespace PavilionsApp.Pages
{
    /// <summary>
    /// Interaction logic for PavilionsEditorPage.xaml
    /// </summary>
    public partial class PavilionsEditorPage : Page
    {
        public PavilionsEditorPage()
        {
            InitializeComponent();

            DataContext = new PavilionsEditorPageVM();
        }
    }
}

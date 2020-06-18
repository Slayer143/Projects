using System.Windows.Controls;

namespace PavilionsApp.Pages
{
    /// <summary>
    /// Interaction logic for BeginnerPage.xaml
    /// </summary>
    public partial class BeginnerPage : Page
    {
        public BeginnerPage()
        {
            InitializeComponent();

            DataContext = new BeginnerPageVM();
        }
    }
}

using System.Windows;

namespace CybersportApp
{
    /// <summary>
    /// Interaction logic for DeleteProfileWindow.xaml
    /// </summary>
    public partial class DeleteProfileWindow : Window
    {
        public DeleteProfileWindow()
        {
            InitializeComponent();

            DataContext = new DeleteProfileWindowVM();
        }
    }
}

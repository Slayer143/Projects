using System;
using System.Windows;

namespace CybersportApp
{
    /// <summary>
    /// Interaction logic for DialogueStartWindow.xaml
    /// </summary>
    public partial class DialogueStartWindow : Window
    {
        public DialogueStartWindow(Guid userId)
        {
            InitializeComponent();

            DataContext = new DialogueStartWindowVM(userId);
        }
    }
}

using Furniture.Domain;
using Furniture.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Furniture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //baseFrame.Content = new StartingPage();

            //baseFrame.Content = new EquipmentPage();

            //baseFrame.Content = new ShowMaterial(true);

            //baseFrame.Content = new Manager();

            //baseFrame.Content = new Master();

            //baseFrame.Content = new Director();

            //baseFrame.Content = new DeputyDirector();

            baseFrame.Content = new Customer(" loginDEyyj2018");

            Viewer.Title = "Furniture Store";
        }
    }
}

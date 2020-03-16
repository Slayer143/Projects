using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Furniture.Pages
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Director : Page
    {
        public Director()
        {
            InitializeComponent();

            pageName.Text = director.Title;
        }

        private void ExitButtonPressed(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Autorisation());
        }

        private void AvailableEquipment(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EquipmentPage());
        }

        private void AddEquipment(object sender, RoutedEventArgs e)
        {
            new NotImplementedException();
        }

        private void NewEquipment(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEquipmentPage());
        }

        private void FurnitureAndMaterialButtonPressed(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShowMaterial(true));
        }
    }
}

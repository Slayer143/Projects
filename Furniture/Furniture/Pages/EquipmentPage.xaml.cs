using Furniture.Connection;
using Furniture.Connection.FurnitureEntities;
using Furniture.Domain;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Furniture.Pages
{
    /// <summary>
    /// Interaction logic for EquipmentPage.xaml
    /// </summary>
    public partial class EquipmentPage : Page
    {
        public EquipmentPage()
        {
            InitializeComponent();

            pageName.Text = equipment.Title;

            ShowEquipment();
        }

        private void BackButtonPressed(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ShowEquipment()
        {
            var domain = new FurnitureDomain();

            var eqList = domain.GetEquipment();

            equipmentList.Dispatcher.Invoke(
               DispatcherPriority.Background,
               new Action(() =>
               {
                   equipmentList.ItemsSource = eqList;
               }));
        }

    }
}

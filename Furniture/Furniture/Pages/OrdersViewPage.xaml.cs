using Furniture.Connection.FurnitureEntities;
using Furniture.Domain;
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
using System.Windows.Threading;

namespace Furniture.Pages
{
    /// <summary>
    /// Interaction logic for OrdersViewPage.xaml
    /// </summary>
    public partial class OrdersViewPage : Page
    {
        private string _userId { get; set; }

        private List<OrderViewModel> _ordersList { get; set; }

        private FurnitureDomain _domain = new FurnitureDomain();

        public OrdersViewPage(string userId)
        {
            InitializeComponent();

            _userId = userId;

            pageName.Text = orders.Title;

            ShowOrders();
        }

        private void BackButtonPressed(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DeleteButtonPressed(object sender, RoutedEventArgs e)
        {
            agreementMessage.Visibility = Visibility.Visible;
            agreeButton.Visibility = Visibility.Visible;
            ordersList.IsEnabled = false;
        }

        private void AgreementButtonPressed(object sender, RoutedEventArgs e)
        {
            _domain.DeleteOrder((ordersList.SelectedItem as OrderViewModel).OrderNumber);

            agreementMessage.Visibility = Visibility.Hidden;
            agreeButton.Visibility = Visibility.Hidden;
            ordersList.IsEnabled = true;

            ShowOrders();
        }

        private void AnotherAgreementButtonPressed(object sender, RoutedEventArgs e)
        {
            _domain.CancelOrder((ordersList.SelectedItem as OrderViewModel));

            agreementMessage.Visibility = Visibility.Hidden;
            anotherAgreeButton.Visibility = Visibility.Hidden;
            ordersList.IsEnabled = true;

            ShowOrders();
        }

        private void DisagreementButtonPressed(object sender, RoutedEventArgs e)
        {
            agreementMessage.Visibility = Visibility.Hidden;
            ordersList.IsEnabled = true;
        }

        private void ShowOrders()
        {
            deleteButton.Visibility = Visibility.Hidden;

            _ordersList = _domain.GetOrdersFromDatabase(_userId);

            ordersList.Dispatcher.Invoke(
               DispatcherPriority.Background,
               new Action(() =>
               {
                   ordersList.ItemsSource = _ordersList;
               }));
        }
        
        private void ItemSelected(object sender, MouseButtonEventArgs e)
        {
            if (((sender as ListView).SelectedItem as  OrderViewModel).Status.Equals("Новый")
                || ((sender as ListView).SelectedItem as OrderViewModel).Status.Equals("Отменен"))
                deleteButton.Visibility = Visibility.Visible;
            else
                deleteButton.Visibility = Visibility.Hidden;

            if (((sender as ListView).SelectedItem as OrderViewModel).Status.Equals("Новый")
                || ((sender as ListView).SelectedItem as OrderViewModel).Status.Equals("Составление спецификации")
                || ((sender as ListView).SelectedItem as OrderViewModel).Status.Equals("Подтверждение"))
                cancelButton.Visibility = Visibility.Visible;
            else
                cancelButton.Visibility = Visibility.Hidden;
        }

        private void CancelButtonPressed(object sender, RoutedEventArgs e)
        {
            agreementMessage.Visibility = Visibility.Visible;
            anotherAgreeButton.Visibility = Visibility.Visible;
            ordersList.IsEnabled = false;
        }
    }
}

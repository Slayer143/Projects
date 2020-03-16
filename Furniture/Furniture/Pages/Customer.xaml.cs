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

namespace Furniture.Pages
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Page
    {
        private string _customerId { get; set; }

        public Customer(string customerId)
        {
            InitializeComponent();

            _customerId = customerId;

            pageName.Text = customer.Title;
        }

        private void ExitButtonPressed(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Autorisation());
        }

        private void MakeNewButtonPressed(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewOrderPage(_customerId));
        }

        private void MyOrdersButtonPressed(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrdersViewPage(_customerId));
        }
    }
}

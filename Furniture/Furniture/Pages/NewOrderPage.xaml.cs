using Furniture.Domain;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Furniture.Pages
{
    /// <summary>
    /// Interaction logic for NewOrderPage.xaml
    /// </summary>
    public partial class NewOrderPage : Page
    {
        private FurnitureDomain _domain = new FurnitureDomain();

        private NewOrderVM _newOrderVM = new NewOrderVM();

        public NewOrderPage(string userId)
        {
            InitializeComponent();

            _newOrderVM.OrderNumber = _domain.CreateOrderNumber(userId);
            _newOrderVM.ProductNames = _domain.GetProducts();
            _newOrderVM.UserId = userId;

            this.DataContext = _newOrderVM;

            pageName.Text = newOrders.Title;
        }

        private void BackButtonPressed(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OpenDialog(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files | *.BMP;*.JPG;*.PDF;*.PNG";
            if (fileDialog.ShowDialog() == true)
            {
                using (FileStream stream = new FileStream(fileDialog.FileName, FileMode.Open))
                {
                    byte[] imageData = new byte[stream.Length];
                    stream.Read(imageData, 0, imageData.Length);
                    _newOrderVM.ImageData = imageData;
                }
            }
        }

        private void SaveOrder(object sender, RoutedEventArgs e)
        {
            if (_newOrderVM.OrderName != string.Empty
                && _newOrderVM.OrderName != null)
            {
                if (_newOrderVM.ProductName != string.Empty
                    && _newOrderVM.ProductName != null)
                {
                    if (_newOrderVM.ProductSize != string.Empty
                        && _newOrderVM.ProductSize != null)
                    {
                        _domain.SaveOrder(
                            _newOrderVM.OrderNumber,
                            DateTimeOffset.Parse(_newOrderVM.OrderDate),
                            _newOrderVM.OrderName,
                            _newOrderVM.ProductName,
                            _newOrderVM.ProductSize,
                            _newOrderVM.UserId,
                            _newOrderVM.ImageData);

                        NavigationService.GoBack();
                    }
                }
            }
        }
    }
}

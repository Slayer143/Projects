using Furniture.Connection;
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

namespace Furniture.Pages
{
    /// <summary>
    /// Interaction logic for EditorPage.xaml
    /// </summary>
    public partial class EditorPage : Page
    {
        private FurnitureDomain _domain = new FurnitureDomain();
        private MaterialAndHardware _item { get; set; }

        public EditorPage(MaterialAndHardware item)
        {
            InitializeComponent();

            pageName.Text = edit.Title;

            _item = item;

            WriteInfoInBoxes();
        }

        private void WriteInfoInBoxes()
        {
            foreach (var point in new string[]
            {
                "Качественный",
                "С незначительными дефектами",
                "Бракованный",
                "Не указана",
                "Показать все"
            })
            {
                qualityBox.Items.Add(point);
            }

            nameBox.Text = _item.Name;
            vendorCodeBox.Text = _item.VendorCode;
            unitBox.Text = _item.Unit;
            countBox.Text = _item.Quantity;
            qualityBox.Text = _item.QualityName;
            priceBox.Text = _item.Price;
            supplierBox.Text = _item.SupplierName;
        }

        private void BackButtonPressed(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CheckChangesButtonPressed(object sender, RoutedEventArgs e)
        {
            if (CheckEmpty())
            {
                agreementMessage.Visibility = Visibility.Visible;
                foreach (var box in editorCanvas.Children)
                {
                    if(box.GetType() == typeof(TextBox))
                    (box as TextBox).IsEnabled = false;
                }
            }
        }

        private bool CheckEmpty()
        {
            return nameBox.Text != string.Empty
                && vendorCodeBox.Text != string.Empty
                && unitBox.Text != string.Empty
                && supplierBox.Text != string.Empty
                && qualityBox.Text != string.Empty
                && countBox.Text != string.Empty
                && priceBox.Text != string.Empty;
        }

        private void AgreementButtonPressed(object sender, RoutedEventArgs e)
        {
            _domain.SaveChanges(
                       new MaterialAndHardware(
                           _item.VendorCode,
                           nameBox.Text,
                           countBox.Text,
                           unitBox.Text,
                           priceBox.Text,
                           supplierBox.Text,
                           qualityBox.Text,
                           _item.ItemType));

            backButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void DisagreementButtonPressed(object sender, RoutedEventArgs e)
        {
            agreementMessage.Visibility = Visibility.Hidden;
            foreach (var box in editorCanvas.Children)
            {
                if (box.GetType() == typeof(TextBox))
                    (box as TextBox).IsEnabled = true;
            }

            vendorCodeBox.IsEnabled = false;
        }
    }
}

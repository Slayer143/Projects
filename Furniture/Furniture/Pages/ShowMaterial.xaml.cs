using Furniture.Connection.FurnitureEntities;
using Furniture.Domain;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Furniture.Pages
{
    /// <summary>
    /// Interaction logic for ShowMaterial.xaml
    /// </summary>
    public partial class ShowMaterial : Page
    {
        public ShowMaterial(bool isEditorPageEnabled)
        {
            InitializeComponent();

            pageName.Text = material.Title;

            if (isEditorPageEnabled)
                materialAndFurnitureList.MouseDoubleClick += ItemDoubleClick;
            else
                materialAndFurnitureList.MouseDoubleClick -= ItemDoubleClick;

            foreach (var point in new string[]
            {
                "Качественный",
                "С незначительными дефектами",
                "Бракованный",
                "Не указана",
                "Показать все"
            })
            {
                filterBox.Items.Add(point);
            }

            if (filterBox.SelectedItem != null)
                Show(filterBox.SelectedItem.ToString());
            else
                Show();
        }

        public void BackButtonPressed(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Show(string condition = null)
        {
            var domain = new FurnitureDomain();

            var matFurList = domain.GetHardwareAndFurniture();

            materialAndFurnitureList.Dispatcher.Invoke(
               DispatcherPriority.Background,
               new Action(() =>
               {
                   if (condition == "Показать все"
                   || condition == null)
                       materialAndFurnitureList.ItemsSource = matFurList;

                   if (condition == "Качественный")
                       materialAndFurnitureList.ItemsSource = matFurList.FindAll(x => x.QualityName == "Качественный");

                   if (condition == "С незначительными дефектами")
                       materialAndFurnitureList.ItemsSource = matFurList.FindAll(x => x.QualityName == "С незначительными дефектами");

                   if (condition == "Бракованный")
                       materialAndFurnitureList.ItemsSource = matFurList.FindAll(x => x.QualityName == "Бракованный");

                   if (condition == "Не указана")
                       materialAndFurnitureList.ItemsSource = matFurList.FindAll(x => x.QualityName == "Не указана");
               }));

            counterBlock.Text = "Всего записей: " +
                matFurList.Count +
                "\nВыбрано сейчас: " +
                materialAndFurnitureList.Items.Count;
        }

        private void FilterChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedItem != null)
                Show((sender as ComboBox).SelectedItem.ToString());
            else
                Show();
        }

        private void ItemDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((sender as ListView).SelectedItem != null)
            {
                NavigationService.Navigate(new EditorPage((sender as ListView).SelectedItem as MaterialAndHardware));
            }
        }
    }
}

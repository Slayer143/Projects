using Furniture.Domain;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Furniture.Pages
{
    /// <summary>
    /// Interaction logic for AddEquipmentPage.xaml
    /// </summary>
    public partial class AddEquipmentPage : Page
    {
        private bool isAddingOk { get; set; }

        private FurnitureDomain domain = new FurnitureDomain();

        private int boxNamePart = 0;

        private int stackPanelNamePart = 0;

        private bool isCharacterNotNull { get; set; }

        private bool isValueNotNull { get; set; }

        public AddEquipmentPage(bool messageVisibility = false)
        {
            InitializeComponent();

            pageName.Text = addEquipment.Title;

            message.Visibility = Visibility.Hidden;

            domain.GetEquipmentTypeFromDatabase(types);

            isAddingOk = messageVisibility;

            if (isAddingOk)
                message.Visibility = Visibility.Visible;
            else
                message.Visibility = Visibility.Hidden;
        }

        private void BackButtonPressed(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Director());
        }

        private void DatePicked(object sender, RoutedEventArgs e)
        {
            date.Text = ((DateTimeOffset)calendar.SelectedDate).DateTime.ToString().Substring(0, 10);
        }

        private void AddBoxes(TextBox sender)
        {
            if (isCharacterNotNull
                    && isValueNotNull)
            {
                isCharacterNotNull = isValueNotNull = false;
                sender.TextChanged -= CharacteristicBoxTextChanged;
                sender.TextChanged -= ValueBoxTextChanged;

                boxNamePart++;

                TextBox firstBox = new TextBox
                {
                    Name = "box" + boxNamePart.ToString(),
                    Height = 50,
                    Width = 269,
                    FontSize = 30,
                };
                firstBox.TextChanged += CharacteristicBoxTextChanged;

                stackPanelNamePart++;

                StackPanel panel = new StackPanel
                {
                    Name = "stackPanel" + stackPanelNamePart.ToString(),
                    Orientation = Orientation.Horizontal
                };

                boxNamePart++;

                TextBox secondBox = new TextBox
                {
                    Name = "box" + boxNamePart.ToString(),
                    Height = 50,
                    Width = 269,
                    FontSize = 30,
                };
                secondBox.TextChanged += ValueBoxTextChanged;

                panel.Children.Add(firstBox);
                panel.Children.Add(secondBox);
                stack.Children.Add(panel);
            }
        }

        private void CharacteristicBoxTextChanged(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text != null)
            {
                isCharacterNotNull = true;

                AddBoxes(sender as TextBox);
            }
        }

        private void AddButtonPressed(object sender, RoutedEventArgs e)
        {
            if (!date.Text.Contains("."))
            {
                date.Background = Brushes.Red;
            }
            else
            {
                if (domain.CheckEquipmentData(
                mark.Text,
                name.Text,
                DateTimeOffset.Parse(date.Text),
                types.Text))
                {
                    domain.AddEquipment(
                        mark.Text,
                        name.Text,
                        DateTimeOffset.Parse(date.Text),
                        Convert.ToInt32(types.Text),
                        stack);

                    Thread.Sleep(1000);

                    NavigationService.Navigate(new AddEquipmentPage(true));
                }
                else
                {
                    message.Visibility = Visibility.Visible;
                    message.Background = Brushes.Red;
                    message.Text = "Проверьте вводимые значения";
                }
            }
        }

        private void ValueBoxTextChanged(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text != null)
            {
                isValueNotNull = true;

                AddBoxes(sender as TextBox);
            }
        }
    }
}

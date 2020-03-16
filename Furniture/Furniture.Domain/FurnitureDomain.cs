using System;
using System.Windows.Media;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Furniture.Connection;
using Microsoft.Win32;
using Image = System.Windows.Controls.Image;
using Furniture.Connection.FurnitureEntities;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Furniture.Domain
{
    public class FurnitureDomain
    {
        public int Role { get; set; }

        public FurnitureDomain()
        {
            Role = 0;
        }

        public FurnitureDomain(int roleId)
        {
            Role = roleId;
        }

        public void ClearTextBox(TextBox box)
        {
            if (box.Text == "Введите логин" ||
                box.Text == "Введите фамилию" ||
                box.Text == "Введите имя" ||
                box.Text == "Введите отчество")
                box.Text = null;
        }

        public void OpenImage(Image image)
        {
            var fileInfo = new OpenFileDialog();

            if (fileInfo.ShowDialog() == true)
            {
                image.Source = (new ImageSourceConverter()).ConvertFromString(fileInfo.FileName) as ImageSource;
            }
        }

        public void GetEquipmentTypeFromDatabase(ComboBox combo)
        {
            using (var context = new FurnitureRepository())
            {
                var list = context.EquipmentType.ToList();

                foreach (var tps in list)
                {
                    combo.Items.Add(tps.TypeId);
                }
            }
        }

        private bool CheckMark(string mark)
        {
            using (var context = new FurnitureRepository())
            {
                var markFromDb = context.Equipment
                    .Where(x => x.Number == mark)
                    .FirstOrDefault();

                return markFromDb == null;
            }
        }

        public bool CheckEquipmentData(
            string mark,
            string name,
            DateTimeOffset orderDate,
            string typeId)
        {
            return mark != string.Empty
                && name != string.Empty
                && orderDate != null
                && typeId != string.Empty
                && CheckMark(mark);
        }

        private List<Characteristics> GetCharacteristics(StackPanel stack)
        {
            List<Characteristics> characteristics = new List<Characteristics>();

            List<StackPanel> panels = new List<StackPanel>();

            foreach (StackPanel panel in stack.Children)
            {
                panels.Add(panel);
            }

            foreach (var panel in panels)
            {
                if ((panel.Children[0] as TextBox).Text != string.Empty
                    && (panel.Children[1] as TextBox).Text != string.Empty)
                {
                    characteristics.Add(new Characteristics(
                    (panel.Children[0] as TextBox).Text,
                    (panel.Children[1] as TextBox).Text));
                }
            }
            return characteristics;
        }

        public void AddEquipment(
            string mark,
            string name,
            DateTimeOffset orderDate,
            int typeId,
            StackPanel stack)
        {
            List<Characteristics> characteristics = GetCharacteristics(stack);

            using (var context = new FurnitureRepository())
            {
                context.Equipment.Add(new Equipment
                {
                    Number = mark,
                    TypeId = typeId,
                    OrderDate = orderDate,
                    Name = name,
                    Details = JsonConvert.SerializeObject(characteristics)
                });

                context.SaveChanges();
            }
        }

        public void AddUserToTheDatabase(
            string login,
            string password,
            int roleId,
            string firstName,
            string lastName,
            string secondName)
        {
            using (var context = new FurnitureRepository())
            {
                context.UserInfo.Add(new UserInfo
                {
                    UserLogin = login,
                    UserPassword = password,
                    RoleId = roleId,
                    FirstName = firstName,
                    LastName = lastName,
                    SecondName = secondName
                });

                context.SaveChanges();
            }
        }

        public bool RegistrationDataCheck(
            string password,
            PasswordBox pass,
            string passwordRepeat,
            PasswordBox repeatPass,
            string login,
            TextBox box,
            string generatedCapture,
            string userInput)
        {
            return (PasswordCheck(
                password,
                passwordRepeat,
                pass,
                repeatPass)
                && LoginCheck(
                    login,
                    box))
                && CaptureCheck(
                    generatedCapture,
                    userInput);
        }

        private bool LoginCheck(string login, TextBox box)
        {
            if (login.Length > 6
                && login != "Введите логин")
            {
                using (var context = new FurnitureRepository())
                {
                    var loginFromDb = context.UserInfo
                        .Where(x => x.UserLogin == login)
                        .FirstOrDefault();

                    box.Background = Brushes.White;
                    return loginFromDb == null;
                }
            }

            box.Background = Brushes.Red;
            return false;
        }

        private bool PasswordCheck(
            string password,
            string passwordRepeat,
            PasswordBox pass,
            PasswordBox repeatPass)
        {
            int passwordLength = password.Length;

            string symbols = "!@#$%^",
                numerals = "1234567890",
                letters = "QWERTYUIOPLKJHGFDSAZXCVBNM";

            if (password == passwordRepeat
                && passwordLength >= 6
                && passwordLength < 18)
            {
                pass.Background = repeatPass.Background = Brushes.White;

                return (password.Intersect(symbols).Count() > 0
                    && password.Intersect(numerals).Count() > 0
                    && password.Intersect(letters).Count() > 0);
            }

            pass.Background = repeatPass.Background = Brushes.Red;
            return false;
        }

        public bool AuthorizeDataCheck(
            string password,
            PasswordBox pass,
            string login,
            TextBox box,
            string generatedCapture,
            string userInput)
        {
            using (var context = new FurnitureRepository())
            {
                var users = context.UserInfo
                    .Where(x => x.UserPassword == password
                    && x.UserLogin == login)
                    .FirstOrDefault();

                if (users != null)
                    Role = users.RoleId;

                if (users != null
                    && CaptureCheck(generatedCapture, userInput))
                    return true;

                box.Background = Brushes.Red;
                pass.Background = Brushes.Red;
                return false;
            }
        }

        private bool CaptureCheck(string generatedCapture, string userInput)
        {
            return generatedCapture.ToLower() == userInput.ToLower();
        }

        public void GenerateCapture(TextBlock capture)
        {
            char[] symbols = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'r', 't', 'y', 'j', 'k', 'n', 'm', 'z', 'x', '1', '2', '3', '5', '6', '7', '8' };

            string captureContent = "";
            Random rand = new Random();
            double offsetCords = 0.00;

            LinearGradientBrush gradient = new LinearGradientBrush()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1)
            };

            for (int i = 0; i < 6; i++)
            {
                gradient.GradientStops.Add(
                    new GradientStop(
                        Color.FromArgb(
                            Convert.ToByte(rand.Next(255)),
                            Convert.ToByte(rand.Next(255)),
                            Convert.ToByte(rand.Next(255)),
                            Convert.ToByte(rand.Next(255))),
                        offsetCords)
                    );

                offsetCords += 0.15;
            }

            capture.Background = gradient;

            captureContent += symbols[rand.Next(6)];
            captureContent += symbols[rand.Next(7, 15)];
            captureContent += symbols[rand.Next(16, 22)];
            captureContent += symbols[rand.Next(6)];
            captureContent += symbols[rand.Next(16, 22)];
            captureContent += symbols[rand.Next(7, 15)];
            captureContent += symbols[rand.Next(6)];

            capture.FontFamily = new FontFamily("Curlz MT");
            capture.Text = captureContent;
        }

        public List<EquipmentData> GetEquipment()
        {
            var dataList = new List<EquipmentData>();

            using (var context = new FurnitureRepository())
            {
                foreach (var eq in context.Equipment.Join(
                    context.EquipmentType,
                    x => x.TypeId,
                    y => y.TypeId,
                    (x, y) => new EquipmentData(
                        x.Number,
                        y.TypeName,
                        JsonConvert.DeserializeObject<List<Characteristics>>(x.Details),
                        x.Name))
                    .ToList())
                {
                    dataList.Add(eq);
                }
            }

            return dataList;
        }

        public List<MaterialAndHardware> GetHardwareAndFurniture()
        {
            var dataList = new List<MaterialAndHardware>();

            using (var context = new FurnitureRepository())
            {
                foreach (var hardware in context.Hardware.Join(
                    context.Quality,
                    x => x.QualityCode,
                    y => y.QualityCode,
                    (x, y) => new MaterialAndHardware(
                        x.VendorCode,
                        x.HardwareName,
                        x.Quantity.ToString(),
                        x.Unit,
                        x.Price.ToString(),
                        x.SupplierName,
                        y.QualityName,
                        "Hardware"))
                    .ToList())
                {
                    dataList.Add(hardware);
                }

                foreach (var material in context.Material.Join(
                    context.Quality,
                    x => x.QualityCode,
                    y => y.QualityCode,
                    (x, y) => new MaterialAndHardware(
                        x.VendorCode,
                        x.MaterialName,
                        x.Quantity.ToString(),
                        x.Unit,
                        x.Price.ToString(),
                        x.SupplierName,
                        y.QualityName,
                        "Material"))
                    .ToList())
                {
                    dataList.Add(material);
                }
            }

            return dataList;
        }

        public void SaveChanges(
            MaterialAndHardware item)
        {
            using (var context = new FurnitureRepository())
            {
                if (item.ItemType == "Material")
                    UpdateMaterial(
                        context,
                        item);
                else
                    UpdateHardware(
                        context,
                        item);
            }
        }

        private void UpdateMaterial(
            FurnitureRepository context,
            MaterialAndHardware item)
        {
            var material = new Material();

            material.VendorCode = item.VendorCode;
            material.Unit = item.Unit;
            material.Quantity = Convert.ToInt32(item.Quantity);
            material.QualityCode = context
                .Quality
                .FirstOrDefault
                (x =>
                x.QualityName == item.QualityName)
                .QualityCode;
            material.Price = Convert.ToDecimal((item.Price).Replace('.', ','));

            if (item.SupplierName != "Не указан")
                material.SupplierName = item.SupplierName;

            material.MaterialName = item.Name;

            context.Material.Update(material);

            context.Entry(material).State = EntityState.Modified;
            context.SaveChanges();
        }

        private void UpdateHardware(
            FurnitureRepository context,
            MaterialAndHardware item)
        {
            var hardware = new Hardware();

            hardware.VendorCode = item.VendorCode;
            hardware.Unit = item.Unit;
            hardware.Quantity = Convert.ToInt32(item.Quantity);
            hardware.QualityCode = context
                .Quality
                .FirstOrDefault
                (x =>
                x.QualityName == item.QualityName)
                .QualityCode;
            hardware.Price = Convert.ToDecimal((item.Price).Replace('.', ','));

            if (item.SupplierName != "Не указан")
                hardware.SupplierName = item.SupplierName;

            hardware.HardwareName = item.Name;

            context.Hardware.Update(hardware);

            context.Entry(hardware).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<OrderViewModel> GetOrdersFromDatabase(string userId)
        {
            var orders = new List<OrderViewModel>();

            using (var context = new FurnitureRepository())
            {
                foreach (var order in context
                    .Order
                    .Where(
                    x => x.Customer.Trim() == userId.Trim())
                    .Join(
                    context.OrderStatus,
                    x => x.StatusId,
                    y => y.StatusId,
                    (x, y) => new OrderViewModel(
                        x.OrderNumber.ToString(),
                        x.OrderDate.ToString(),
                        x.OrderName,
                        x.ProductName,
                        x.Customer,
                        x.Manager,
                        x.Price.ToString(),
                        x.CompleteDate.ToString(),
                        y.Status))
                    .ToList())
                {
                    orders.Add(order);
                }
            }

            return orders;
        }

        public void DeleteOrder(string orderNumber)
        {
            using (var context = new FurnitureRepository())
            {
                var order = new Order
                {
                    OrderNumber = orderNumber
                };

                context.Order.Attach(order);
                context.Order.Remove(order);
                context.SaveChanges();
            }
        }

        public void CancelOrder(OrderViewModel model)
        {
            using (var context = new FurnitureRepository())
            {
                var order = new Order
                {
                    OrderNumber = model.OrderNumber,
                    OrderName = model.OrderName,
                    OrderDate = DateTimeOffset.Parse(model.OrderDate),
                    Customer = model.Customer,
                    ProductName = model.ProductName,
                    StatusId = 2
                };

                context.Order.Update(order);

                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public string CreateOrderNumber(string userId)
        {
            string orderNumber = null;
            char firstLetter;

            using (var context = new FurnitureRepository())
            {
                firstLetter = context
                    .UserInfo
                    .Where(x =>
                    x.UserLogin.Trim()
                    .Equals(userId.Trim()))
                    .FirstOrDefault()
                    .LastName[0];

                if (firstLetter != ' ')
                    orderNumber += char.ToUpper(firstLetter);
                else
                    orderNumber += '_';

                firstLetter = context
                    .UserInfo
                    .Where(x =>
                    x.UserLogin.Trim()
                    .Equals(userId.Trim()))
                    .FirstOrDefault()
                    .FirstName[0];

                if (firstLetter != ' ')
                    orderNumber += char.ToUpper(firstLetter);
                else
                    orderNumber += '_';

                if (DateTimeOffset.Now.Month < 10)
                    orderNumber += $"0{DateTimeOffset.Now.Month}";
                else
                    orderNumber += DateTimeOffset.Now.Month.ToString();

                int num = 0;
                num += (from order in context.Order
                        where order.Customer.Trim().Equals(userId.Trim())
                              && order.OrderDate.Month.Equals(DateTimeOffset.Now.Month)
                              && order.OrderDate.Year.Equals(DateTimeOffset.Now.Year)
                        select order).Count();

                if (Convert.ToInt32(num) < 10)
                    orderNumber += $"0{num}";
                else
                    orderNumber += num;

                if (DateTimeOffset.Now.Day < 10)
                    orderNumber += $"0{DateTimeOffset.Now.Day}";
                else
                    orderNumber += DateTimeOffset.Now.Day;

                return orderNumber += DateTimeOffset.Now.Year;
            }
        }

        public ObservableCollection<string> GetProducts()
        {
            using (var context = new FurnitureRepository())
            {
                var namesList = new ObservableCollection<string>();

                foreach (var name in context.Product)
                {
                    namesList.Add(name.ProductName);
                }

                return namesList;
            }
        }

        public void SaveOrder(
            string orderNumber,
            DateTimeOffset orderDate,
            string orderName,
            string productName,
            string productSize,
            string customer,
            byte[] scheme)
        {
            using (var context = new FurnitureRepository())
            {
                context.Order.Add(new Order
                {
                    OrderNumber = orderNumber,
                    OrderDate = orderDate,
                    OrderName = orderName,
                    ProductName = productName,
                    Customer = customer,
                    Scheme = scheme,
                    StatusId = 1,
                    ProductSize = productSize
                });

                context.SaveChanges();
            }
        }
    }
}

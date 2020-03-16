using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Pages
{
    public class NewOrderVM : INotifyPropertyChanged
    {
        private string _userId { get; set; }
        private string _orderNum { get; set; }

        private string _orderDate { get; set; }

        private byte[] _imageData { get; set; }

        private string _orderName { get; set; }

        private string _productName { get; set; }

        private ObservableCollection<string> _productNames { get; set; }

        private string _productSize { get; set; }

        public string UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                OnPropertyChanged("UserId");
            }
        }

        public string OrderName
        {
            get { return _orderName; }
            set
            {
                _orderName = value;
                OnPropertyChanged("OrderName");
            }
        }

        public ObservableCollection<string> ProductNames
        {
            get { return _productNames; }
            set
            {
                _productNames = value;
                OnPropertyChanged("ProductNames");
            }
        }

        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                OnPropertyChanged("ProductName");
            }
        }

        public string ProductSize
        {
            get { return _productSize; }
            set
            {
                _productSize = value;
                OnPropertyChanged("ProductSize");
            }
        }

        public byte[] ImageData
        {
            get { return _imageData; }
            set
            {
                _imageData = value;
                OnPropertyChanged("ImageData");
            }
        }

        public string OrderNumber
        {
            get
            { return _orderNum; }
            set
            {
                _orderNum = value;
                OnPropertyChanged("OrderNumber");
            }
        }

        public string OrderDate
        {
            get
            { return _orderDate; }
            set
            {
                _orderDate = value;
                OnPropertyChanged("OrderDate");
            }
        }

        public NewOrderVM()
        {
            OrderDate = DateTimeOffset.Now.UtcDateTime.ToString().Substring(0, 10);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}

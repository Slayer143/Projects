using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Connection.FurnitureEntities
{
    public class OrderViewModel
    {
        public string OrderNumber { get; set; }

        public string OrderDate { get; set; }

        public string OrderName { get; set; }

        public string ProductName { get; set; }

        public string Customer { get; set; }

        public string Manager { get; set; }

        public string Price { get; set; }

        public string CompleteDate { get; set; }

        public string Status { get; set; }

        public OrderViewModel(
            string orderNumber,
            string orderDate,
            string orderName,
            string productName,
            string customer,
            string manager,
            string price,
            string completeDate,
            string status)
        {
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            OrderName = orderName;
            ProductName = productName;
            Customer = customer;

            if (manager == null)
                Manager = "Не указан";
            else
                Manager = manager;

            if (price == null
                || price == "0.00")
                Price = "Не указана";
            else
                Price = price.ToString();

            if (completeDate == null
                || completeDate == "0001-01-01")
                CompleteDate = "Не указана";
            else
                CompleteDate = completeDate.ToString();

            Status = status;
        }
    }
}

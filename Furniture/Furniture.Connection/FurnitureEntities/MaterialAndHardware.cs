using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Connection.FurnitureEntities
{
    public class MaterialAndHardware
    {
        [Key]
        public string VendorCode { get; set; }

        public string Name { get; set; }

        public string Quantity { get; set; }

        public string Unit { get; set; }

        public string Price { get; set; }

        public string SupplierName { get; set; }

        public string QualityName { get; set; }

        public string ItemType { get; set; }

        public MaterialAndHardware(
            string code,
            string name,
            string quantity,
            string unit,
            string price,
            string supplier,
            string quality,
            string itemType)
        {
            if (price == null)
                price = "Не указана";

            if (quantity == null)
                quantity = "Не указано";

            if (supplier == null)
                supplier = "Не указан";

            Quantity = quantity;
            Price = price;
            VendorCode = code;
            Name = name;
            Unit = unit;
            SupplierName = supplier;
            QualityName = quality;
            ItemType = itemType;
        }
    }
}

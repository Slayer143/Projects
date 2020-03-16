using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Connection.FurnitureEntities
{
    public class Material
    {
        [Key]
        public string VendorCode { get; set; }

        [Required]
        public string MaterialName { get; set; }

        public string Unit { get; set; }

        public int Quantity { get; set; }

        public string SupplierName { get; set; }

        public string MaterialType { get; set; }

        public decimal Price { get; set; }

        public string GOST { get; set; }

        public int MaterialLength { get; set; }

        public string Details { get; set; }

        [Required]
        public int QualityCode { get; set; }

        public string Photo { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Furniture.Connection.FurnitureEntities
{
    public class Hardware 
    {
        [Key]
        public string VendorCode { get; set; }

        [Required]
        public string HardwareName { get; set; }

        [Required]
        public string Unit { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string SupplierName { get; set; }

        [Required]
        public string ComponentsType { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int FurnitureWeight { get; set; }

        public int QualityCode { get; set; }

        public string Photo { get; set; }
    }
}

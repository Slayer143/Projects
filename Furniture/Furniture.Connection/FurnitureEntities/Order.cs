using System;
using System.ComponentModel.DataAnnotations;

namespace Furniture.Connection.FurnitureEntities
{
    public class Order
    {
        [Key]
        public string OrderNumber { get; set; }

        [Required]
        public DateTimeOffset OrderDate { get; set; }

        [Required]
        public string OrderName { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Customer { get; set; }

        public string Manager { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset CompleteDate { get; set; }

        public byte[] Scheme { get; set; }

        public int StatusId { get; set; }

        public string ProductSize { get; set; }
    }
}

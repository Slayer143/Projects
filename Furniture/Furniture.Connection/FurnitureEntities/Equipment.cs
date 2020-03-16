using System;
using System.ComponentModel.DataAnnotations;

namespace Furniture.Connection.FurnitureEntities
{
    public class Equipment
    {
        [Key]
        public string Number { get; set; }

        [Required]
        public int TypeId { get; set; }

        public string Details { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTimeOffset OrderDate { get; set; }
    }
}

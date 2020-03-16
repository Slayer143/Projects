using System.ComponentModel.DataAnnotations;

namespace Furniture.Connection.FurnitureEntities
{
    public class EquipmentType
    {
        [Key]
        public int TypeId { get; set; }

        [Required]
        public string TypeName { get; set; }
    }
}

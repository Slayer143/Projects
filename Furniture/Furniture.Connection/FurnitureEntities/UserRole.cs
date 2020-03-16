using System.ComponentModel.DataAnnotations;

namespace Furniture.Connection.FurnitureEntities
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }

        public string RoleName { get; set; }
    }
}

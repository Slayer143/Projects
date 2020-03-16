using System.ComponentModel.DataAnnotations;

namespace Furniture.Connection.FurnitureEntities
{
    public class UserInfo
    {
        [Key]
        public string UserLogin { get; set; }

        [Required]
        public string UserPassword { get; set; }

        [Required]
        public int RoleId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SecondName { get; set; }

        public string Photo { get; set; }
    }
}

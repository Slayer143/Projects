using System.ComponentModel.DataAnnotations;

namespace CybersportApp.Core.CybersportEntities
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

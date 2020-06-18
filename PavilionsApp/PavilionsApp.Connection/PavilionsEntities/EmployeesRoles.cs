using System.ComponentModel.DataAnnotations;

namespace PavilionsApp.Connection.PavilionsEntities
{
    public class EmployeesRoles
    { 
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}

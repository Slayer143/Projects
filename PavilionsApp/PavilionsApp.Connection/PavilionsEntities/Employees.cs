using System.ComponentModel.DataAnnotations;

namespace PavilionsApp.Connection.PavilionsEntities
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public int GenderId { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SecondName { get; set; }

        public byte[] Photo { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}

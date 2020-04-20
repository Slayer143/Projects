using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

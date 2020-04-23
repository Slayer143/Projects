using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportApp.Core.CybersportEntities
{
    public class AccountStatuses
    {
        [Key]
        public int AccountStatusId { get; set; }
        
        [Required]
        public string Status { get; set; }
    }
}

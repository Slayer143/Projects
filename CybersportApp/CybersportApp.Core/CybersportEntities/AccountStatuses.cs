using System.ComponentModel.DataAnnotations;

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

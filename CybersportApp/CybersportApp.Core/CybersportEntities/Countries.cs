using System.ComponentModel.DataAnnotations;

namespace CybersportApp.Core.CybersportEntities
{
    public class Countries
    {
        [Key]
        public int CountryId { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}

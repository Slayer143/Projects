using System.ComponentModel.DataAnnotations;

namespace CybersportApp.Core.CybersportEntities
{
    public class Teams
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        public string ShortName { get; set; }

        public int DisciplineId { get; set; }

        public int CountryId { get; set; }
    }
}

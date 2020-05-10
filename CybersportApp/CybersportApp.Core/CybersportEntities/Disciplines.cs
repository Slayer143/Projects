using System.ComponentModel.DataAnnotations;

namespace CybersportApp.Core.CybersportEntities
{
    public class Disciplines
    {
        [Key]
        public int DisciplineId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

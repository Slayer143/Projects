using System.ComponentModel.DataAnnotations;

namespace CybersportApp.Core.CybersportEntities
{
    public class TournamentsTypes
    {
        [Key]
        public int TournamentTypeId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

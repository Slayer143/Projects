using System;
using System.ComponentModel.DataAnnotations;

namespace CybersportApp.Core.CybersportEntities
{
    public class TournamentsWins
    {
        public Guid UserId { get; set; }

        public int TournamentId { get; set; }

        [Required]
        public int Place { get; set; }
    }
}

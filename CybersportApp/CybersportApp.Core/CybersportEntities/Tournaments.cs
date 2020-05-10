using System;
using System.ComponentModel.DataAnnotations;

namespace CybersportApp.Core.CybersportEntities
{
    public class Tournaments
    {
        [Key]
        public int TournamentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal PrizePool { get; set; }

        [Required]
        public decimal FirstPlacePrize { get; set; }

        [Required]
        public decimal SecondPlacePrize { get; set; }

        [Required]
        public decimal ThirdPlacePrize { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        [Required]
        public int Participants { get; set; }

        [Required]
        public int TournamentTypeId { get; set; }

        [Required]
        public int DisciplineId { get; set; }
    }
}

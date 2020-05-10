using System;
using System.ComponentModel.DataAnnotations;

namespace CybersportApp.Core.CybersportEntities
{
    public class PlayersInformation
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public int RatingId { get; set; }

        [Required]
        public int DisciplineId { get; set; }

        [Required]
        public int AccountStatusId { get; set; }

        public decimal TotalEarnings { get; set; }

        public int CareerStartYear { get; set; }

        public PlayersInformation() { }

        public PlayersInformation(Guid id)
        {
            UserId = id;
            RatingId = 0;
            DisciplineId = 0;
            AccountStatusId = 2;
            TotalEarnings = Convert.ToDecimal(0);
            CareerStartYear = 0;
        }
    }
}

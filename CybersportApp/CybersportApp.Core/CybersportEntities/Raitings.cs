using System.ComponentModel.DataAnnotations;

namespace CybersportApp.Core.CybersportEntities
{
    public class Ratings
    {
        [Key]
        public int RatingId { get; set; }

        [Required]
        public string RatingValue { get; set; }
    }
}

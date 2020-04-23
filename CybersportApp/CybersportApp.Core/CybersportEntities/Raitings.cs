using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using System.ComponentModel.DataAnnotations;

namespace PavilionsApp.Connection.PavilionsEntities
{
    public class Pavilions
    {
        [Key]
        public int PavilionId { get; set; }

        [Required]
        public int CenterId { get; set; }

        [Required]
        public string PavilionNumber { get; set; }

        [Required]
        public int Floor { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public decimal Square { get; set; }

        [Required]
        public decimal CostPerSquare { get; set; }

        [Required]
        public decimal ValueFactor { get; set; }
    }
}

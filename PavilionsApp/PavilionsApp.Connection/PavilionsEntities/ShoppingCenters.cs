using System.ComponentModel.DataAnnotations;

namespace PavilionsApp.Connection.PavilionsEntities
{
    public class ShoppingCenters
    {
        [Key]
        public int CenterId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public int PavilionsQuantity { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public decimal ValueFactor { get; set; }

        [Required]
        public int FloorsQuantity { get; set; }

        public byte[] Image { get; set; }
    }
}

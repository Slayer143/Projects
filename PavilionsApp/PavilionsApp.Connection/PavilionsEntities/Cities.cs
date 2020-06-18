using System.ComponentModel.DataAnnotations;

namespace PavilionsApp.Connection.PavilionsEntities
{
    public class Cities
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

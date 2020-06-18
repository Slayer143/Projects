using System.ComponentModel.DataAnnotations;

namespace PavilionsApp.Connection.PavilionsEntities
{
    public class PavilionsStatuses
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        public string Status { get; set; }
    }
}

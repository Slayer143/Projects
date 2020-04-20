using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportApp.Core.CybersportEntities
{
    public class Teams
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        public string ShortName { get; set; }

        public int DisciplineId { get; set; }

        public int CountryId { get; set; }
    }
}

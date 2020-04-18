using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportApplication.Core.Entities
{
    public class Countries
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        public string Name { get; set; }

        public byte[] Flag { get; set; }
    }
}

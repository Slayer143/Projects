using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionsApp.Connection.PavilionsEntities
{
    public class Genders
    {
        [Key]
        public int GenderId { get; set; }

        [Required]
        public char Gender { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSMarathon
{
    public class WSMarathonCountry
    {
        [Key]
        public string CountryCode {get; set;}
        public string CountryName { get; set; }
        public string CountryFlag { get; set; }
    }
}

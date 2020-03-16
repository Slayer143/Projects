using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Connection.FurnitureEntities
{
    public class Quality
    {
        [Key]
        public int QualityCode { get; set; }

        [Required]
        public string QualityName { get; set; }
    }
}

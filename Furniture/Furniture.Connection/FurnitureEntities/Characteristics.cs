using System.ComponentModel.DataAnnotations;

namespace Furniture.Connection.FurnitureEntities
{
    public class Characteristics
    {
        [Key]
        public string Name { get; set; }

        public string Value { get; set; }

        public Characteristics(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}

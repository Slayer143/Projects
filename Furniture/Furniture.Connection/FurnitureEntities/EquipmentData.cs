using System.Collections.Generic;

namespace Furniture.Connection.FurnitureEntities
{
    public class EquipmentData
    {
        public List<Characteristics> Details { get; set; }

        public string CharVal { get; set; }

        public string Number { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public EquipmentData(
            string num,
            string type,
            List<Characteristics> details,
            string name)
        {
            CharVal = null;

            Number = num;
            Type = type;
            Details = details;
            Name = name;

            foreach (var detail in Details)
            {
                CharVal += detail.Name + " : " + detail.Value + ";\n";
            }
        }
    }
}

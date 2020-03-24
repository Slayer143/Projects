using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancySearch.Connection
{
    public class Vacancy
    {
        public string SubdivisionName { get; set; }

        public string PositionName { get; set; }

        public int Count { get; set; }

        public Vacancy(
            string subName,
            string posName,
            int count)
        {
            SubdivisionName = subName;
            PositionName = posName;
            Count = count;
        }
    }
}

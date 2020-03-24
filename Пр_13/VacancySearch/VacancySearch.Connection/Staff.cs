using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancySearch.Connection
{
    public class Staff
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string SecondName { get; set; }

        public char Gender { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        public string EducationLevel { get; set; }

        public string PhoneNumber { get; set; }

        public string SubdivisionName { get; set; }

        public string PositionName { get; set; }

        public Staff(
            string name,
            string lastName,
            string secondName,
            char gender,
            string birthDate,
            string education,
            string phone,
            string subName,
            string posName)
        {
            Name = name;
            LastName = lastName;
            SecondName = secondName;
            Gender = gender;
            BirthDate = DateTimeOffset.Parse(birthDate.Substring(11));
            EducationLevel = education;
            PhoneNumber = phone;
            SubdivisionName = subName;
            PositionName = posName;
        }
    }
}

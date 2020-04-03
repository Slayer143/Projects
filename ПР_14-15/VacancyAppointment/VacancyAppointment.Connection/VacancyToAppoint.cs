using System;

namespace VacancyAppointment.Connection
{
    public class VacancyToAppoint
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }

        public string Gender { get; set; }

        public string BirthDate { get; set; }

        public string EducationLevel { get; set; }

        public string Phone { get; set; }

        public string Subdivision { get; set; }

        public string Position { get; set; }

        public VacancyToAppoint(
            int id,
            string lastName,
            string name,
            string secondName,
            string gender,
            string birthDate,
            string educationLevel,
            string phone,
            string subdivision,
            string position)
        {
            Id = id;
            LastName = lastName;
            Name = name;
            SecondName = secondName;
            Gender = gender;
            BirthDate = birthDate;
            EducationLevel = educationLevel;
            Phone = phone;
            Subdivision = subdivision;
            Position = position;
        }
    }
}

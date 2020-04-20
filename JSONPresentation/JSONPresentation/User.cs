using System;
using System.Collections.Generic;
using System.Text;

namespace JSONPresentation
{
    public class User
    {
        public string LastName { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public char Gender { get; set; }

        public string Role { get; set; }

        public User() {}

        public User(
            string lastName,
            string name,
            int age,
            char gender,
            string role)
        {
            LastName = lastName;
            Name = name;
            Age = age;
            Gender = gender;
            Role = role;
        }
    }
}

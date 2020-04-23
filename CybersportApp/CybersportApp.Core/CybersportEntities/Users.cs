﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CybersportApp.Core.CybersportEntities
{
    public class Users
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Name { get; set; }

        public string SecondName { get; set; }

        [Required]
        public DateTimeOffset BirthDate { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int RoleId { get; set; }

        public int TeamId { get; set; }

        public byte[] Photo { get; set; }

        public Users() { }

        public Users(
            string login,
            string password,
            string lastName,
            string name,
            DateTimeOffset birthDate,
            int countryId,
            int roleId,
            byte[] photo)
        {
            UserId = Guid.NewGuid();
            Login = login;
            Password = password;
            LastName = lastName;
            Name = name;
            BirthDate = birthDate;
            CountryId = countryId;
            RoleId = roleId;
            Photo = photo;
            SecondName = null;
            TeamId = 100;
        }
    }
}
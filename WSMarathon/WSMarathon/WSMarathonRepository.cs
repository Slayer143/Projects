using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSMarathon
{
    class WSMarathonRepository : DbContext
    {
        private string _connectionString { get; set; }
        public DbSet<WSMarathonCountry> Country { get; set; }
        public DbSet<WSMarathonGender> Gender { get; set; }

        public WSMarathonRepository()
            :this(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Marathon_skills_2016;Integrated Security=true;")
        {
        }

        public WSMarathonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}

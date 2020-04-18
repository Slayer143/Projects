using CybersportApplication.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportApplication.Core
{
    public class CybersportRepository : DbContext
    {
        private string _connectionString { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Countries> Countries { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public CybersportRepository()
            : this(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=CybersportDb;Integrated Security=true;")
        {
        }

        public CybersportRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}

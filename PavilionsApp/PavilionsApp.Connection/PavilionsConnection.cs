using Microsoft.EntityFrameworkCore;
using PavilionsApp.Connection.PavilionsEntities;

namespace PavilionsApp.Connection
{
    public class PavilionsConnection : DbContext
    {
        private string _connectionString { get; set; }

        public DbSet<Employees> Employees { get; set; }

        public DbSet<EmployeesRoles> EmployeesRoles { get; set; }

        public DbSet<Genders> Genders { get; set; }

        public DbSet<Cities> Cities { get; set; }

        public DbSet<ShoppingCentersStatuses> ShoppingCentersStatuses { get; set; }

        public DbSet<ShoppingCenters> ShoppingCenters { get; set; }

        public DbSet<Pavilions> Pavilions { get; set; }

        public DbSet<PavilionsStatuses> PavilionsStatuses { get; set; }

        public PavilionsConnection()
            : this(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=PavilionsDb;Integrated Security=true;")
        {
        }

        public PavilionsConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}

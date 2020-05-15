using CybersportApp.Core.CybersportEntities;
using Microsoft.EntityFrameworkCore;

namespace CybersportApp.Core
{
    public class CybersportConnection : DbContext
    {
        private string _connectionString { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Countries> Countries { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<Teams> Teams { get; set; }

        public DbSet<Disciplines> Disciplines { get; set; }

        public DbSet<Tournaments> Tournaments { get; set; }

        public DbSet<TournamentsTypes> TournamentsTypes { get; set; }

        public DbSet<AccountStatuses> AccountStatuses { get; set; }

        public DbSet<Ratings> Ratings { get; set; }

        public DbSet<PlayersInformation> PlayersInformation { get; set; }

        public DbSet<Messages> Messages { get; set; }

        public DbSet<TournamentsWins> TournamentsWins { get; set; }

        public CybersportConnection()
            : this(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=CybersportDb;Integrated Security=true;")
        {
        }

        public CybersportConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TournamentsWins>().HasKey(x => new { x.UserId, x.TournamentId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}

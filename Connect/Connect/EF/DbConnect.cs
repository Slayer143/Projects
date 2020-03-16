namespace Connect.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbConnect : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public DbConnect()
            : base("name=TestConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

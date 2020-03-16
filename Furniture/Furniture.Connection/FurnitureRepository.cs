using Furniture.Connection.FurnitureEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Connection
{
    public class FurnitureRepository : DbContext
    {

        private string _connectionString { get; set;}

        public DbSet<Quality> Quality { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderStatus> OrderStatus { get; set; }

        public DbSet<Hardware> Hardware { get; set; }

        public DbSet<Material> Material { get; set; }

        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<UserRole> UserRole { get; set; }

        public DbSet<Equipment> Equipment { get; set; }

        public DbSet<EquipmentType> EquipmentType { get; set; }


        public FurnitureRepository()
            :this(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=ZakazMebely;Integrated Security=true;")
        { 
        }

        public FurnitureRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}

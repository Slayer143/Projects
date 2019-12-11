using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDemo
{
	public class ReminderItemsDbContext : DbContext
	{
		private string _connectionString;

		public DbSet<ReminderItem> ReminderItems { get; set; }

		public ReminderItemsDbContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		public ReminderItemsDbContext()
			: this(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=ReminderEFCore;Integrated Security=true;")
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}
	}
}

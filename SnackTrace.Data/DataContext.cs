using Microsoft.EntityFrameworkCore;
using SnackTrace.Data.Models;

namespace SnackTrace.Data
{
	public class DataContext : DbContext
	{
		public DbSet<Snack> Snacks { get; set; }
		public DbSet<Drink> Drinks { get; set; }
		public DbSet<Menu> Menus { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=.;Database=SnackTrace;Integrated Security=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Multiple snacks <-> multiple menus relationship
			modelBuilder.Entity<Menu>()
				.HasMany(i => i.Snacks)
				.WithMany(i => i.Menus);

			// Multiple drinks <-> multiple menus relationship
			modelBuilder.Entity<Menu>()
				.HasMany(i => i.Drinks)
				.WithMany(i => i.Menus);

			
		}
	}
}

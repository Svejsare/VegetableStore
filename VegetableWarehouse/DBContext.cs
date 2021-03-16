using Microsoft.EntityFrameworkCore;
using VegetableWarehouse.Repositories.Models;

namespace LocalDB
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Vegetable> Vegetables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vegetable>()
                .HasKey(x => x.Id);
        }
    }
}
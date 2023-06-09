using Microsoft.EntityFrameworkCore;
using OrderManagement.Shared.Entities;
using System.Diagnostics.Metrics;

namespace OrderManagement.API.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TypeFlavor> TypeFlavor { get; set; }
        public DbSet<TypeProduct> TypeProduct { get; set; }
        public DbSet<Product> Product { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}

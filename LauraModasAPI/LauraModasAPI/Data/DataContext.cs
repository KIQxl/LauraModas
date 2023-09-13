using LauraModasAPI.Data.Configurations;
using LauraModasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LauraModasAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts):base(opts)
        {
            
        }

        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<BuyModel> Buys { get; set; }
        public DbSet<InstallmentModel> Installments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new BuyConfiguration());
            modelBuilder.ApplyConfiguration(new InstallmentConfiguration());
        }
    }
}

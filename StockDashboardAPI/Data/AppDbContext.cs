using Microsoft.EntityFrameworkCore;
using StockDashboardAPI.Models;

namespace StockDashboardAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CompanyOverview> CompanyOverview { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompanyOverview>().ToTable("CompanyOverview");
        }
    }
}

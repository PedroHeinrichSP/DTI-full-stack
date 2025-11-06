using LeadManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Lead> Leads => Set<Lead>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lead>().ToTable("Leads");
        }
    }
}

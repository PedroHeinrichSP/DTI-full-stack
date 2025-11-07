using LeadManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Lead> Leads => Set<Lead>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Lead>().ToTable("Leads");

        modelBuilder.Entity<Lead>(entity =>
        {
            entity.Property(e => e.Price).HasPrecision(18, 2);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.Property(e => e.DateCreated)
                  .HasDefaultValueSql("GETUTCDATE()");
        });

        // seed data
        modelBuilder.Entity<Lead>().HasData(
            new Lead
            {
                Id = 1,
                FirstName = "João",
                LastName = "Silva",
                Category = "Eletricista",
                Suburb = "São Paulo",
                Description = "Instalações e manutenções elétricas residenciais.",
                Price = 800m,
                Email = "joao.silva@email.com",
                Phone = "11999999999",
                Status = "invited",
                DateCreated = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
            },
            new Lead
            {
                Id = 2,
                FirstName = "Maria",
                LastName = "Souza",
                Category = "Pintora",
                Suburb = "Campinas",
                Description = "Serviços de pintura residencial e comercial.",
                Price = 450m,
                Email = "maria.souza@email.com",
                Phone = "11988888888",
                Status = "invited",
                DateCreated = new DateTime(2025, 01, 02, 0, 0, 0, DateTimeKind.Utc)
            },
            new Lead
            {
                Id = 3,
                FirstName = "Carlos",
                LastName = "Lima",
                Category = "Encanador",
                Suburb = "Santos",
                Description = "Reparo e instalação hidráulica completa.",
                Price = 1200m,
                Email = "carlos.lima@email.com",
                Phone = "11977777777",
                Status = "accepted",
                DateCreated = new DateTime(2025, 01, 03, 0, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}

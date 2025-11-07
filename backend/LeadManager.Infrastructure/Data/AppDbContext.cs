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

        // seed data (dados fictícios gerados por LLM)
        modelBuilder.Entity<Lead>().HasData(
            new Lead { Id = 1, FirstName = "João", LastName = "Silva", Category = "Eletricista", Suburb = "São Paulo", Description = "Instalações elétricas residenciais.", Price = 800m, Email = "joao.silva@email.com", Phone = "11999999999", Status = "invited", DateCreated = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Lead { Id = 2, FirstName = "Maria", LastName = "Souza", Category = "Pintora", Suburb = "Campinas", Description = "Pintura residencial e comercial.", Price = 450m, Email = "maria.souza@email.com", Phone = "11988888888", Status = "invited", DateCreated = new DateTime(2025, 1, 2, 0, 0, 0, DateTimeKind.Utc) },
            new Lead { Id = 3, FirstName = "Carlos", LastName = "Lima", Category = "Encanador", Suburb = "Santos", Description = "Reparo e instalação hidráulica.", Price = 1200m, Email = "carlos.lima@email.com", Phone = "11977777777", Status = "accepted", DateCreated = new DateTime(2025, 1, 3, 0, 0, 0, DateTimeKind.Utc) },
            new Lead { Id = 4, FirstName = "Fernanda", LastName = "Oliveira", Category = "Jardineira", Suburb = "São Paulo", Description = "Serviços de jardinagem e paisagismo.", Price = 300m, Email = "fernanda.oliveira@email.com", Phone = "11966666666", Status = "invited", DateCreated = new DateTime(2025, 1, 4, 0, 0, 0, DateTimeKind.Utc) },
            new Lead { Id = 5, FirstName = "Rafael", LastName = "Costa", Category = "Marceneiro", Suburb = "Guarulhos", Description = "Móveis planejados sob medida.", Price = 950m, Email = "rafael.costa@email.com", Phone = "11955555555", Status = "invited", DateCreated = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
            new Lead { Id = 6, FirstName = "Patrícia", LastName = "Ferreira", Category = "Diarista", Suburb = "Santo André", Description = "Limpeza residencial e comercial.", Price = 250m, Email = "patricia.ferreira@email.com", Phone = "11944444444", Status = "invited", DateCreated = new DateTime(2025, 1, 6, 0, 0, 0, DateTimeKind.Utc) },
            new Lead { Id = 7, FirstName = "Diego", LastName = "Mendes", Category = "Pedreiro", Suburb = "Osasco", Description = "Reformas e construções gerais.", Price = 1100m, Email = "diego.mendes@email.com", Phone = "11933333333", Status = "invited", DateCreated = new DateTime(2025, 1, 7, 0, 0, 0, DateTimeKind.Utc) },
            new Lead { Id = 8, FirstName = "Aline", LastName = "Pereira", Category = "Decoradora", Suburb = "Barueri", Description = "Design de interiores e consultoria de ambientes.", Price = 600m, Email = "aline.pereira@email.com", Phone = "11922222222", Status = "invited", DateCreated = new DateTime(2025, 1, 8, 0, 0, 0, DateTimeKind.Utc) },
            new Lead { Id = 9, FirstName = "Fábio", LastName = "Nunes", Category = "Técnico em Ar Condicionado", Suburb = "São Caetano", Description = "Instalação e manutenção de ar-condicionado.", Price = 500m, Email = "fabio.nunes@email.com", Phone = "11911111111", Status = "invited", DateCreated = new DateTime(2025, 1, 9, 0, 0, 0, DateTimeKind.Utc) },
            new Lead { Id = 10, FirstName = "Camila", LastName = "Rodrigues", Category = "Faxineira", Suburb = "Diadema", Description = "Serviços de faxina e limpeza rápida.", Price = 200m, Email = "camila.rodrigues@email.com", Phone = "11900000000", Status = "invited", DateCreated = new DateTime(2025, 1, 10, 0, 0, 0, DateTimeKind.Utc) }
        );
    }
}

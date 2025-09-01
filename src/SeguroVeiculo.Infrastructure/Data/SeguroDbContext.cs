using Microsoft.EntityFrameworkCore;
using SeguroVeiculo.Domain.Entities;

namespace SeguroVeiculo.Infrastructure.Data
{
    public class SeguroDbContext : DbContext
    {
        public SeguroDbContext(DbContextOptions<SeguroDbContext> options)
            : base(options)
        { }

        public DbSet<Segurado> Segurados => Set<Segurado>();
        public DbSet<Seguro> Seguros => Set<Seguro>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Evitar pluralização de tabelas
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }

            // Configuração de Seguro
            modelBuilder.Entity<Seguro>(entity =>
            {
                entity.ToTable("Seguro");
                entity.HasKey(s => s.Id);
            });

            // Configuração de Segurado
            modelBuilder.Entity<Segurado>(entity =>
            {
                entity.ToTable("Segurado");
                entity.HasKey(s => s.Id);
            });

        }
    }
}
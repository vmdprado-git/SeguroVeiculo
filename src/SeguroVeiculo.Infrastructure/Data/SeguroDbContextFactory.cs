using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SeguroVeiculo.Infrastructure.Data
{
    public class SeguroDbContextFactory : IDesignTimeDbContextFactory<SeguroDbContext>
    {
        public SeguroDbContext CreateDbContext(string[] args)
        {
            // Definir a string de conexão usada para migrations
            var optionsBuilder = new DbContextOptionsBuilder<SeguroDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SeguroVeiculo;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;");

            return new SeguroDbContext(optionsBuilder.Options);
        }
    }
}

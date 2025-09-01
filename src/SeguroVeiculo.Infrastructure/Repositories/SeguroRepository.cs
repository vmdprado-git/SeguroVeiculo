using Microsoft.EntityFrameworkCore;
using SeguroVeiculo.Domain.Entities;
using SeguroVeiculo.Domain.Interfaces;
using SeguroVeiculo.Infrastructure.Data;

namespace SeguroVeiculo.Infrastructure.Repositories
{
    public class SeguroRepository : ISeguroRepository
    {
        private readonly SeguroDbContext _context;

        public SeguroRepository(SeguroDbContext context)
        {
            _context = context;
        }

        public async Task<Seguro> AdicionarAsync(Seguro seguro)
        {
            _context.Seguros.Add(seguro);
            await _context.SaveChangesAsync();
            return seguro;
        }

        public async Task<Seguro?> ObterPorIdAsync(int id)
        {
            return await _context.Seguros
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Seguro>> ObterTodosAsync()
        {
            return await _context.Seguros
                .ToListAsync();
        }
    }
}

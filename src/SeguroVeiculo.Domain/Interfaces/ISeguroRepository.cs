using SeguroVeiculo.Domain.Entities;

namespace SeguroVeiculo.Domain.Interfaces
{
    public interface ISeguroRepository
    {
        Task<Seguro> AdicionarAsync(Seguro seguro);
        Task<Seguro?> ObterPorIdAsync(int id);
        Task<IEnumerable<Seguro>> ObterTodosAsync();
    }
}

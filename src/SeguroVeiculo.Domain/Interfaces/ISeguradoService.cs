using SeguroVeiculo.Domain.Entities;

namespace SeguroVeiculo.Domain.Interfaces
{
    public interface ISeguradoService
    {
        Task<Segurado?> ObterSeguradoPorIdAsync(int seguradoId);
    }
}

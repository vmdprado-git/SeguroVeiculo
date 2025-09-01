using SeguroVeiculo.Domain.Entities;
using SeguroVeiculo.Domain.Interfaces;

namespace SeguroVeiculo.Application.UseCases
{
    public class ObterSeguroUseCase
    {
        private readonly ISeguroRepository _repository;

        public ObterSeguroUseCase(ISeguroRepository repository)
        {
            _repository = repository;
        }

        public async Task<Seguro?> Executar(int id)
        {
            return await _repository.ObterPorIdAsync(id);
        }
    }
}

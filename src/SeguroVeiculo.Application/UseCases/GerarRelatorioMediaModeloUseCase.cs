using SeguroVeiculo.Domain.Interfaces;
using SeguroVeiculo.Domain.Entities;

namespace SeguroVeiculo.Application.UseCases
{
    public class GerarRelatorioMediaModeloUseCase
    {
        private readonly ISeguroRepository _repository;

        public GerarRelatorioMediaModeloUseCase(ISeguroRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RelatorioMedia>> Executar()
        {
            var seguros = await _repository.ObterTodosAsync();

            if (seguros == null || !seguros.Any())
                return new List<RelatorioMedia>();

            var relatorio = seguros
                .GroupBy(s => s.Marca + '-' + s.Modelo) 
                .Select(g => new RelatorioMedia
                {
                    MarcaModelo = g.Key,
                    ValorMedia = g.Average(s => s.ValorSeguro),
                    TotalSeguros = g.Count()
                })
                .OrderBy(r => r.MarcaModelo) 
                .ToList();

            return relatorio;
        }
    }
}

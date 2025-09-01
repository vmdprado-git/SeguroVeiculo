using SeguroVeiculo.Domain.Entities;
using SeguroVeiculo.Domain.Interfaces;

namespace SeguroVeiculo.Application.UseCases
{
    public class CriarSeguroUseCase
    {
        private readonly ISeguroRepository _repository;

        public CriarSeguroUseCase(ISeguroRepository repository)
        {
            _repository = repository;
        }

        public async Task<Seguro> Executar(SeguroRequest seguroRequest)
        {
            if (seguroRequest == null || seguroRequest.ValorVeiculo <= 0)
                throw new ArgumentException("Dados inválidos para criar o seguro.");

            Seguro seguro = new Seguro();
            seguro.IdSegurado = seguroRequest.IdSegurado;
            seguro.Marca = seguroRequest.Marca;
            seguro.Modelo = seguroRequest.Modelo;
            seguro.ValorVeiculo = seguroRequest.ValorVeiculo;
            
            // Lógica de cálculo do prêmio 
            CalcularSeguroUseCase calcularSeguroUseCase = new CalcularSeguroUseCase();
            CalculoSeguro calculoSeguro = calcularSeguroUseCase.Calcular(seguro.ValorVeiculo);
            seguro.ValorSeguro = calculoSeguro.ValorSeguro;

            // Persistência via repositório
            return await _repository.AdicionarAsync(seguro);
        }
        
    }
}

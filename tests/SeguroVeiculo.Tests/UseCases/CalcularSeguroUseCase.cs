using FluentAssertions;
using SeguroVeiculo.Application.UseCases;
using SeguroVeiculo.Domain.Entities;
using Xunit;

namespace SeguroVeiculo.Tests.UseCases
{
    public class CalcularSeguroUseCaseTests
    {
        private readonly CalcularSeguroUseCase _useCase;

        public CalcularSeguroUseCaseTests()
        {
            _useCase = new CalcularSeguroUseCase();
        }

        [Fact(DisplayName = "Deve calcular o seguro com base no valor do veículo")]
        public void DeveCalcularSeguro_Base5Porcento()
        {
            var request = new CalculoSeguroRequest
            {
                ValorVeiculo = 10000
            };
            var resultado = _useCase.Execute(request);
            resultado.ValorSeguro.Should().Be(270.37m);
        }

    }
}

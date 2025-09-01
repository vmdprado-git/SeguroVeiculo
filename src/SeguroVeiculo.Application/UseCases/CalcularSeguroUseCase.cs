using System.IO.Pipes;
using SeguroVeiculo.Domain.Entities;

namespace SeguroVeiculo.Application.UseCases
{
    public class CalcularSeguroUseCase
    {

        private const decimal MARGEM_SEGURANCA = 0.03m;
        private const decimal LUCRO = 0.05m;

        public CalculoSeguro Execute(CalculoSeguroRequest calculoSeguroRequest)
        {
            CalculoSeguro retorno;
            if (calculoSeguroRequest.ValorVeiculo <= 0)
                throw new ArgumentException("Dados inválidos para cálculo.");

            retorno = Calcular(calculoSeguroRequest.ValorVeiculo);
            return retorno;
        }

        public CalculoSeguro Calcular(decimal valorVeiculo)
        {
            decimal taxaRisco = (valorVeiculo * 5) / (2 * valorVeiculo);
            decimal premioRisco = taxaRisco * valorVeiculo / 100;
            decimal premioPuro = premioRisco * (1 + MARGEM_SEGURANCA);
            decimal premioComercial = Math.Round(premioPuro * (1 + LUCRO), 2, MidpointRounding.ToZero);

            CalculoSeguro retorno = new CalculoSeguro();
            retorno.ValorVeiculo = valorVeiculo;
            retorno.TaxaRisco = taxaRisco;
            retorno.PremioRisco = premioRisco;
            retorno.PremioPuro = premioPuro;
            retorno.PremioComercial = premioComercial;
            retorno.ValorSeguro = premioComercial;
            return retorno;
        }
    }
}

namespace SeguroVeiculo.Domain.Entities
{
    public class CalculoSeguro
    {
        public decimal ValorVeiculo { get; set; }
        public decimal TaxaRisco { get; set; }
        public decimal PremioRisco { get; set; }
        public decimal PremioPuro { get; set; }
        public decimal PremioComercial { get; set; }
        public decimal ValorSeguro { get; set; }
    }
}

namespace SeguroVeiculo.Domain.Entities
{
    public class RelatorioMedia
    {
        public string MarcaModelo { get; set; } = string.Empty;
        public decimal ValorMedia { get; set; } 
        public int TotalSeguros { get; set; } 
    }
}
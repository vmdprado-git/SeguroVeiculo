namespace SeguroVeiculo.Mvc.Models
{
    public class RelatorioMediaViewModel
    {
        public string MarcaModelo { get; set; } = string.Empty;
        public decimal ValorMedia { get; set; } 
        public int TotalSeguros { get; set; } 
    }
}

namespace SeguroVeiculo.Domain.Entities
{
    public class SeguroRequest
    {
        public int IdSegurado { get; set; }
        public string Marca { get; set; } = string.Empty;    
        public string Modelo { get; set; } = string.Empty;        
        public decimal ValorVeiculo { get; set; }    
    }
}

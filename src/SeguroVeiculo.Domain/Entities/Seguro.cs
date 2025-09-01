namespace SeguroVeiculo.Domain.Entities
{
    public class Seguro
    {
        public int Id { get; set; }
        public int IdSegurado { get; set; }
        public string Marca { get; set; } = string.Empty;    
        public string Modelo { get; set; } = string.Empty;        
        public decimal ValorVeiculo { get; set; }    
        public decimal ValorSeguro { get; set; }
        public DateTime DataContratacao { get; set; } = DateTime.Now;
    }
}

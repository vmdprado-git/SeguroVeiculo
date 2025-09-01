using SeguroVeiculo.Mvc.Models;
using System.Net.Http.Json;

namespace SeguroVeiculo.Mvc.Services
{
    public class RelatorioMediaService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "http://localhost:5087/api/Seguro/relatorio-media"; 
        public RelatorioMediaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<RelatorioMediaViewModel>> ObterRelatorioAsync()
        {
            try
            {
                var resultado = await _httpClient.GetFromJsonAsync<List<RelatorioMediaViewModel>>(ApiUrl);
                return resultado ?? new List<RelatorioMediaViewModel>();
            }
            catch
            {
                return new List<RelatorioMediaViewModel>();
            }
        }
    }
}

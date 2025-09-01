using System.Net.Http.Json;
using SeguroVeiculo.Domain.Entities;
using SeguroVeiculo.Domain.Interfaces;

namespace SeguroVeiculo.Infrastructure.Services
{
    public class SeguradoService : ISeguradoService
    {
        private readonly HttpClient _httpClient;
        public SeguradoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Segurado?> ObterSeguradoPorIdAsync(int seguradoId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/segurados/{seguradoId}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Segurado>();
            }
            catch (Exception)
            {
                Segurado ret = new Segurado();
                ret.Id = seguradoId;
                ret.Nome = "REST FAKE está on?";
                return ret;
            }
        }
    }
}

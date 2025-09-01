using Microsoft.AspNetCore.Mvc;
using SeguroVeiculo.Application.UseCases;
using SeguroVeiculo.Domain.Entities;

namespace SeguroVeiculo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguroController : ControllerBase
    {
        private readonly CalcularSeguroUseCase _calcularSeguroUseCase;
        private readonly CriarSeguroUseCase _criarSeguroUseCase;
        private readonly ObterSeguroUseCase _obterSeguroUseCase;
        private readonly GerarRelatorioMediaModeloUseCase _gerarRelatorioMediaModeloUseCase;

        public SeguroController(
            CalcularSeguroUseCase calcularSeguroUseCase,
            CriarSeguroUseCase criarSeguroUseCase,
            ObterSeguroUseCase obterSeguroUseCase,
            GerarRelatorioMediaModeloUseCase gerarRelatorioMediaModeloUseCase)
        {
            _calcularSeguroUseCase = calcularSeguroUseCase;
            _criarSeguroUseCase = criarSeguroUseCase;
            _obterSeguroUseCase = obterSeguroUseCase;
            _gerarRelatorioMediaModeloUseCase = gerarRelatorioMediaModeloUseCase;
        }

        [HttpPost("calcular")]
        public IActionResult Calcular([FromBody] CalculoSeguroRequest request)
        {
            if (request == null || request.ValorVeiculo <= 0)
                return BadRequest("Dados inválidos");

            var retorno = _calcularSeguroUseCase.Execute(request);

            return Ok(new
            {
                CalculoSeguro = retorno
            });
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] SeguroRequest seguro)
        {
            try
            {
                var seguroCriado = await _criarSeguroUseCase.Executar(seguro);
                return CreatedAtAction(nameof(ObterPorId), new { id = seguroCriado.Id }, seguroCriado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("pesquisar-seguro")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var seguro = await _obterSeguroUseCase.Executar(id);

            if (seguro == null)
                return NotFound("Seguro não encontrado.");

            return Ok(seguro);
        }    

        [HttpGet("relatorio-media")]
        public async Task<IActionResult> GerarRelatorioMedia()
        {
            var relatorio = await _gerarRelatorioMediaModeloUseCase.Executar();
            return Ok(relatorio);
        }   
    }
}

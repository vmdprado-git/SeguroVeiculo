using Microsoft.AspNetCore.Mvc;
using SeguroVeiculo.Mvc.Services;

namespace SeguroRelatorioFront.Controllers
{
    public class RelatorioMediaController : Controller
    {
        private readonly RelatorioMediaService _relatorioMediaService;

        public RelatorioMediaController(RelatorioMediaService relatorioMediaService)
        {
            _relatorioMediaService = relatorioMediaService;
        }

        public async Task<IActionResult> Index()
        {
            var relatorio = await _relatorioMediaService.ObterRelatorioAsync();
            return View(relatorio);
        }
    }
}

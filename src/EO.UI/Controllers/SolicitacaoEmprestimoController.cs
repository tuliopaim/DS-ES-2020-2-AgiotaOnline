using System.Threading.Tasks;
using EO.Application.Interfaces;
using EO.Application.ViewModels.InputModels.SolicitacaoEmprestimo;
using Microsoft.AspNetCore.Mvc;

namespace EO.UI.Controllers
{
    public class SolicitacaoEmprestimoController : BaseController
    {
        private readonly ISolicitacaoEmprestimoAppService _appService;

        public SolicitacaoEmprestimoController(
            ISolicitacaoEmprestimoAppService appService)
        {
            _appService = appService;
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarSolicitacao(CriarSolicitacaoEmprestimo model)
        {
            model.TomadorId = ObterIdUsuarioLogado();

            await _appService.Adicionar(model);

            return View("Criar");
        }
    }
}
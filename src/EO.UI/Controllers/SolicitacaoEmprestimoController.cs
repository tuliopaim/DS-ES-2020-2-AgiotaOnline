using System.Threading.Tasks;
using EO.Application.Interfaces;
using EO.Application.ViewModels.InputModels.SolicitacaoEmprestimo;
using FluentValidation.AspNetCore;
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
            model.UsuarioId = ObterIdUsuarioLogado();

            var result = await _appService.Adicionar(model);

            if(result.IsValid) return RedirectToAction("Index", "Home");

            result.AddToModelState(ModelState, "");

            return View("Criar");
        }
    }
}
using System.Threading.Tasks;
using EO.Application.ViewModels.InputModels.SolicitacaoEmprestimo;
using Microsoft.AspNetCore.Mvc;

namespace EO.UI.Controllers
{
    public class SolicitacaoEmprestimoController : BaseController
    {
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarSolicitacao(CriarSolicitacaoEmprestimo model)
        {
            model.TomadorId = ObterIdUsuarioLogado();



            return View("Criar");
        }
    }
}
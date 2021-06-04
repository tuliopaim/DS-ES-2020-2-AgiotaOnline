using Microsoft.AspNetCore.Mvc;

namespace EO.UI.Controllers
{
    public class SolicitacaoEmprestimoController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}
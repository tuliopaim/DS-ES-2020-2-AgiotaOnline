using System.Threading.Tasks;
using EO.Application.ViewModels.InputModels;
using EO.Domain.Entities;
using EO.UI.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EO.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly UserManager<User> _userManager;

        public AccountController(
            SignInManager<User> signInManager,
            ILogger<LoginModel> logger,
            UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RealizarLogin(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View("Login", model);

            var result = await _signInManager.PasswordSignInAsync(
                model.Email,
                model.Password, 
                model.RememberMe, 
                false);

            if (result.Succeeded) return RedirectToAction("Index", "Home");

            ModelState.AddModelError(string.Empty, "Login incorreto.");

            return View("Login", model);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View(new CriarUsuarioViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario(CriarUsuarioViewModel model)
        {
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                Cpf = model.Cpf,
                Telefone = model.Telefone,
                ChavePix = model.ChavePix,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View("Registrar");
        }

        [HttpGet]
        public IActionResult TrocarSenha()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RealizarTrocaDeSenha()
        {
            return View("TrocarSenha");
        }
    }
}
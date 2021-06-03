using System.Threading.Tasks;
using EO.Application.Interfaces;
using EO.Application.ViewModels.InputModels.Usuario;
using EO.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EO.UI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<Usuario> _userManager;
        private readonly IUsuarioAppService _usuarioAppService;

        public AccountController(
            SignInManager<Usuario> signInManager,
            UserManager<Usuario> userManager,
            ILogger<AccountController> logger,
            IUsuarioAppService usuarioAppService)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _usuarioAppService = usuarioAppService;
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
            var result = await _usuarioAppService.AdicionarUsuario(model);

            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            
            return View("Registrar");
        }

        [HttpGet]
        public IActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RealizarTrocaDeSenha(TrocarSenhaViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            
            var result = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
            if (result.Succeeded)
            {
                return User.Identity?.IsAuthenticated ?? false
                    ? RedirectToAction("Index", "Home")
                    : RedirectToAction("Login", "Account");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View("AlterarSenha");
        }

        [HttpPost]
        public async Task<IActionResult> RealizarLogout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Editar()
        {
            var id = ObterIdUsuarioLogado();

            var model = await _usuarioAppService.ObterUsuarioParaEdicao(id);

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditarPerfil(EditarUsuarioViewModel model)
        {
            if (!ModelState.IsValid) return View("Editar", model);

            await _usuarioAppService.EditarUsuario(model);

            return RedirectToAction("Index", "Home");
        }
    }
}
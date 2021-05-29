using System.Threading.Tasks;
using EO.Application.Interfaces;
using EO.Application.ViewModels.InputModels.Usuario;
using EO.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EO.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IUserAppService _userAppService;

        public AccountController(
            SignInManager<User> signInManager,
            ILogger<AccountController> logger,
            UserManager<User> userManager,
            IUserAppService userAppService)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _userAppService = userAppService;
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
            var user = new User(model.Nome, model.Cpf, model.Telefone, model.ChavePix)
            {
                UserName = model.Email,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
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

            var senhaCorreta = await _signInManager
                .CheckPasswordSignInAsync(user, model.Password, false);

            if (!senhaCorreta.Succeeded)
            {
                ModelState.AddModelError(nameof(model.Password), "Senha incorreta!");
                
                return View("AlterarSenha");
            }

            if (user == null)
            {
                return RedirectToPage("./ResetPasswordConfirmation");
            }

            var result = await _userManager.ResetPasswordAsync(user, "", model.NewPassword);
            if (result.Succeeded)
            {
                return RedirectToPage("./ResetPasswordConfirmation");
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
        public IActionResult Perfil()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> EditarPerfil(EditarUsuarioViewModel model)
        {
            if (!ModelState.IsValid) return View("Perfil", model);

            await _userAppService.AtualizarUsuario(model);

            return View("Perfil");
        }
    }
}
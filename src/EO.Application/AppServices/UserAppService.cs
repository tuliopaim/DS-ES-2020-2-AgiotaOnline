using System;
using System.Security.Claims;
using System.Threading.Tasks;
using EO.Application.Interfaces;
using EO.Application.ViewModels.InputModels.Usuario;
using EO.Domain.Entities;
using EO.Domain.Enums;
using EO.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EO.Application.AppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IFornecedorAppService _fornecedorAppService;
        private readonly ITomadorAppService _tomadorAppService;
        private readonly IUnitOfWork _unitOfWork;

        public UserAppService(
            IUserRepository userRepository,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IFornecedorAppService fornecedorAppService,
            ITomadorAppService tomadorAppService,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _fornecedorAppService = fornecedorAppService;
            _tomadorAppService = tomadorAppService;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AdicionarUsuario(CriarUsuarioViewModel model)
        {
            await _unitOfWork.InitTransaction();

            try
            {
                var user = new User(
                    model.Nome,
                    model.Cpf,
                    model.Telefone,
                    model.ChavePix,
                    model.TipoUsuario)
                { UserName = model.Email, Email = model.Email };

                var result = await CriarUsuarioIdentity(model, user);
                if (!result.Succeeded) return false;
                
                //todo: configurar notificador
                
                CriarUsuarioEspecifico(model, user);

                await _unitOfWork.CommitTransaction();
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        private async Task<IdentityResult> CriarUsuarioIdentity(CriarUsuarioViewModel model, User user)
        {
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return result;

            await _userManager.AddClaimAsync(user, new Claim(nameof(user.Nome), user.Nome));
            await _userManager.AddClaimAsync(user, new Claim("TipoUsuario", user.Tipo.ToString()));

            await _signInManager.SignInAsync(user, true);
            
            return result;
        }

        private void CriarUsuarioEspecifico(CriarUsuarioViewModel model, User user)
        {
            if (model.TipoUsuario == TipoUsuario.Fornecedor)
            {
                _fornecedorAppService.Adicionar(model.Fornecedor, user.Id);
            }
            else
            {
                _tomadorAppService.Adicionar(model.Tomador, user.Id);
            }
        }

        public async Task<EditarUsuarioViewModel> ObterUsuarioParaEdicao(int id)
        {
            var user = await _userRepository.ObterPorId(id);

            var editarViewModel = new EditarUsuarioViewModel
            {
                Id = id,
                Telefone = user.Telefone,
                ChavePix = user.ChavePix,
                Tipo = user.Tipo,
            };

            if (user.Tipo == TipoUsuario.Fornecedor)
            {
                editarViewModel.Fornecedor = await _fornecedorAppService.ObterParaEdicao(user.Id);
            }
            else
            {
                editarViewModel.Tomador = await _tomadorAppService.ObterParaEdicao(user.Id);
            }

            return editarViewModel;
        }

        public async Task AtualizarUsuario(EditarUsuarioViewModel model)
        {
            var user = await _userRepository.ObterPorId(model.Id, true);

            user.AlterarTelefone(model.Telefone);
            user.AlterarChavePix(model.ChavePix);

            if (user.Tipo == TipoUsuario.Fornecedor)
            {
                await _fornecedorAppService.AtualizarFornecedor(model.Fornecedor);
            }
            else
            {
                await _tomadorAppService.AtualizarTomador(model.Tomador);
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
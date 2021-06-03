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
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly IFornecedorAppService _fornecedorAppService;
        private readonly ITomadorAppService _tomadorAppService;
        private readonly IUnitOfWork _unitOfWork;

        public UserAppService(
            IUserRepository userRepository,
            SignInManager<Usuario> signInManager,
            UserManager<Usuario> userManager,
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
                var user = new Usuario(
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

        private async Task<IdentityResult> CriarUsuarioIdentity(CriarUsuarioViewModel model, Usuario usuario)
        {
            var result = await _userManager.CreateAsync(usuario, model.Password);
            if (!result.Succeeded) return result;

            await _userManager.AddClaimAsync(usuario, new Claim(nameof(usuario.Nome), usuario.Nome));
            await _userManager.AddClaimAsync(usuario, new Claim("TipoUsuario", usuario.Tipo.ToString()));

            await _signInManager.SignInAsync(usuario, true);
            
            return result;
        }

        private void CriarUsuarioEspecifico(CriarUsuarioViewModel model, Usuario usuario)
        {
            if (model.TipoUsuario == TipoUsuario.Fornecedor)
            {
                _fornecedorAppService.Adicionar(model.Fornecedor, usuario.Id);
            }
            else
            {
                _tomadorAppService.Adicionar(model.Tomador, usuario.Id);
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

        public async Task EditarUsuario(EditarUsuarioViewModel model)
        {
            var user = await _userRepository.ObterPorId(model.Id, true);

            user.AlterarNome(model.Nome);
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
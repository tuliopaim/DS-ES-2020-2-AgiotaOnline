using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using EO.Application.Interfaces;
using EO.Application.ViewModels.InputModels.Usuario;
using EO.Domain.Entities;
using EO.Domain.Enums;
using EO.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EO.Application.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly IFornecedorAppService _fornecedorAppService;
        private readonly ITomadorAppService _tomadorAppService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioAppService(
            IUsuarioRepository usuarioRepository,
            SignInManager<Usuario> signInManager,
            UserManager<Usuario> userManager,
            IFornecedorAppService fornecedorAppService,
            ITomadorAppService tomadorAppService,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _fornecedorAppService = fornecedorAppService;
            _tomadorAppService = tomadorAppService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
            var usuario = await _usuarioRepository.ObterPorId(id);

            var editarViewModel = _mapper.Map<EditarUsuarioViewModel>(usuario);

            if (usuario.Tipo == TipoUsuario.Fornecedor)
            {
                editarViewModel.Fornecedor = await _fornecedorAppService.ObterParaEdicao(usuario.Id);
            }
            else
            {
                editarViewModel.Tomador = await _tomadorAppService.ObterParaEdicao(usuario.Id);
            }

            return editarViewModel;
        }

        public async Task EditarUsuario(EditarUsuarioViewModel model)
        {
            var usuario = await _userManager.FindByIdAsync(model.Id.ToString());

            if (usuario.Nome != model.Nome)
            {
                usuario.AlterarNome(model.Nome);

                await AtualizarClaimNome(usuario);
            }

            usuario.AlterarTelefone(model.Telefone);
            usuario.AlterarChavePix(model.ChavePix);

            if (usuario.Tipo == TipoUsuario.Fornecedor)
            {
                await _fornecedorAppService.AtualizarFornecedor(model.Fornecedor);
            }
            else
            {
                await _tomadorAppService.AtualizarTomador(model.Tomador);
            }

            await _unitOfWork.SaveChangesAsync();

            await _signInManager.RefreshSignInAsync(usuario);
        }

        private async Task AtualizarClaimNome(Usuario usuario)
        {
            var claims = await _userManager.GetClaimsAsync(usuario);
            var claimNome = claims.FirstOrDefault(c => c.Type == nameof(usuario.Nome));

            if (claimNome is null)
            {
                await _userManager.AddClaimAsync(usuario, new Claim(nameof(usuario.Nome), usuario.Nome));
                return;
            }

            await _userManager.ReplaceClaimAsync(usuario, claimNome, new Claim(claimNome.Type, usuario.Nome));
        }
    }
}
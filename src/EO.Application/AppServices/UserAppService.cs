using System.Threading.Tasks;
using EO.Application.Interfaces;
using EO.Application.ViewModels.InputModels.Usuario;
using EO.Domain.Interfaces;

namespace EO.Application.AppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<EditarUsuarioViewModel> ObterUsuarioParaEdicao(int id)
        {
            var user = await _userRepository.ObterPorId(id);

            return new EditarUsuarioViewModel
            {
                Id = id,
                Telefone = user.Telefone,
                ChavePix = user.ChavePix,
            };
        }

        public async Task AtualizarUsuario(EditarUsuarioViewModel model)
        {
            var user = await _userRepository.ObterPorId(model.Id, true);

            user.AlterarTelefone(model.Telefone);
            user.AlterarChavePix(model.ChavePix);

            await _userRepository.Atualizar(user);
        }
    }
}
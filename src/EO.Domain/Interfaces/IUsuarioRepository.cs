using System.Threading.Tasks;
using EO.Domain.Entities;

namespace EO.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterPorId(int id, bool track = false);
        void Atualizar(Usuario usuario);
    }
}
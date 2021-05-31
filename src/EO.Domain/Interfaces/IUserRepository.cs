using System.Threading.Tasks;
using EO.Domain.Entities;

namespace EO.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Usuario> ObterPorId(int id, bool track = false);
        void Atualizar(Usuario usuario);
    }
}
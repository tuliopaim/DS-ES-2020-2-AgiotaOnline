using System.Threading.Tasks;
using EO.Domain.Entities;

namespace EO.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> ObterPorId(int id, bool track = false);
        void Atualizar(User user);
    }
}
using System.Threading.Tasks;
using EO.Domain.Entities;

namespace EO.Domain.Interfaces
{
    public interface ITomadorRepository : IGenericRepository<Tomador>
    {
        Task<Tomador> ObterPorUsuarioIdCompleto(int id, bool track = false);

        Task<Tomador> ObterPorIdCompleto(int id, bool track = false);
    }
}
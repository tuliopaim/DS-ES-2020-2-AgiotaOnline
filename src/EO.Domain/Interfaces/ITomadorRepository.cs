using System.Threading.Tasks;
using EO.Domain.Entities;

namespace EO.Domain.Interfaces
{
    public interface ITomadorRepository : IGenericRepository<Tomador>
    {
        Task<Tomador> ObterPorUsuarioId(int id, bool track = false);

    }
}
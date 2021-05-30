using System.Threading.Tasks;
using EO.Domain.Entities;
using EO.Domain.Interfaces;
using EO.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EO.Infra.Repositories
{
    public class TomadorRepository : GenericRepository<Tomador>, ITomadorRepository
    {
        private readonly ApplicationContext _context;

        public TomadorRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Tomador> ObterPorUsuarioId(int id, bool track = false)
        {
            return await BuildQuery(x => x.UserId == id)
                .Include(x => x.Endereco)
                .FirstOrDefaultAsync();
        }
    }
}
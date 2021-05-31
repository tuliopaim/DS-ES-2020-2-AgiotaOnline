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

        public async Task<Tomador> ObterPorUsuarioIdCompleto(int id, bool track = false)
        {
            return await BuildQuery(x => x.UsuarioId == id, track: track)
                .Include(x => x.Endereco)
                .FirstOrDefaultAsync();
        }

        public async Task<Tomador> ObterPorIdCompleto(int id, bool track = false)
        {
            return await BuildQuery(x => x.Id == id, track: track)
                .Include(x => x.Endereco)
                .FirstOrDefaultAsync();
        }
    }
}
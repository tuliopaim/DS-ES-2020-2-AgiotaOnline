using System.Threading.Tasks;
using EO.Domain.Entities;
using EO.Domain.Interfaces;
using EO.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EO.Infra.Repositories
{
    public class FornecedorRepository : GenericRepository<Fornecedor>, IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Fornecedor> ObterPorUsuarioId(int id, bool track = false)
        {
            return await BuildQuery(x => x.UsuarioId == id, track: track)
                .Include(x => x).FirstOrDefaultAsync();
        }

        public async Task<Fornecedor> ObterPorId(int id, bool track = false)
        {
            return await BuildQuery(x => x.Id == id, track: track)
                .Include(x => x).FirstOrDefaultAsync();
        }
    }
}
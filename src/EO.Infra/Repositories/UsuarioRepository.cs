using System.Threading.Tasks;
using EO.Domain.Entities;
using EO.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EO.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public async Task<Usuario> ObterPorId(int id, bool track = false)
        {
            var query = _context.Users.AsQueryable();

            if (!track) query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Atualizar(Usuario usuario)
        {
            if (_context.Entry(usuario).State == EntityState.Detached)
            {
                _context.Users.Attach(usuario);
            }

            _context.Entry(usuario).State = EntityState.Modified;
        }
    }
}
using System.Threading.Tasks;
using EO.Domain.Entities;
using EO.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EO.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public async Task<User> ObterPorId(int id, bool track = false)
        {
            var query = _context.Users.AsQueryable();

            if (!track) query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Atualizar(User user)
        {
            if (_context.Entry(user).State == EntityState.Detached)
            {
                _context.Users.Attach(user);
            }

            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EO.Domain.Entities;
using EO.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EO.Infra.Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entidade
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Remove(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }
        
        public virtual void Update(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.CountAsync(expression);
        }
        
        public virtual async Task<T> GetByIdAsync(int id, bool track = false)
        {
            return await BuildQuery(track: track).FirstOrDefaultAsync(x => x.Id == id);
        }

        protected IQueryable<T> BuildQuery(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? skip = null,
            int? take = null,
            bool track = false)
        {
            var query = _dbSet.AsQueryable();

            if (!track) query = query.AsNoTracking();

            if (expression != null) query = query.Where(expression);
            
            query = orderBy != null ? orderBy(query) : query.OrderBy(x => x.DataCriacao);

            if (skip.HasValue) query = query.Skip(skip.Value);

            if (take.HasValue) query = query.Take(take.Value);

            return query;
        }
        
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
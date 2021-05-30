using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EO.Domain.Interfaces
{
    public interface IGenericRepository<T> : IDisposable
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id, bool track = false);
    }
}
using System.Threading.Tasks;

namespace EO.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        Task InitTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();

    }
}
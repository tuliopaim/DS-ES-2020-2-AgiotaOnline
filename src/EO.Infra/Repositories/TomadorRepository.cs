using EO.Application.Interfaces;
using EO.Domain.Entities;
using EO.Infra.Repositories.Base;

namespace EO.Infra.Repositories
{
    public class FornecedorRepository : GenericRepository<Fornecedor>, IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
using EO.Domain.Entities;
using EO.Domain.Interfaces;
using EO.Infra.Repositories.Base;

namespace EO.Infra.Repositories
{
    public class SolicitacaoEmprestimoRepository : GenericRepository<SolicitacaoEmprestimo>, ISolicitacaoEmprestimoRepository
    {
        public SolicitacaoEmprestimoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
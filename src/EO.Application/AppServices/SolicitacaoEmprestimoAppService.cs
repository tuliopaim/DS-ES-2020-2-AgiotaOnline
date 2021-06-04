using EO.Application.Interfaces;
using EO.Domain.Interfaces;

namespace EO.Application.AppServices
{
    public class SolicitacaoEmprestimoAppService : ISolicitacaoEmprestimoAppService
    {
        private readonly ISolicitacaoEmprestimoRepository _repository;
        private readonly IUnitOfWork _uow;

        public SolicitacaoEmprestimoAppService(
            ISolicitacaoEmprestimoRepository repository,
            IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }



    }
}
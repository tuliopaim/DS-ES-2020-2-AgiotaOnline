using System.Threading.Tasks;
using EO.Application.Interfaces;
using EO.Application.ViewModels.InputModels.SolicitacaoEmprestimo;
using EO.Domain.Entities;
using EO.Domain.Interfaces;
using FluentValidation.Results;

namespace EO.Application.AppServices
{
    public class SolicitacaoEmprestimoAppService : ISolicitacaoEmprestimoAppService
    {
        private readonly ISolicitacaoEmprestimoRepository _repository;
        private readonly ITomadorRepository _tomadorRepository;
        private readonly IUnitOfWork _uow;

        public SolicitacaoEmprestimoAppService(
            ISolicitacaoEmprestimoRepository repository,
            ITomadorRepository tomadorRepository,
            IUnitOfWork uow)
        {
            _repository = repository;
            _tomadorRepository = tomadorRepository;
            _uow = uow;
        }


        public async Task<ValidationResult> Adicionar(CriarSolicitacaoEmprestimo model)
        {
            var solicitacao = new SolicitacaoEmprestimo(model.Valor, model.Parcelas);
            
            _repository.Add(solicitacao);

            await _uow.SaveChangesAsync();

            return new ValidationResult();
        }
    }
}
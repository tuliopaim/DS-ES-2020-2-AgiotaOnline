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
            IUnitOfWork uow, ITomadorRepository tomadorRepository)
        {
            _repository = repository;
            _uow = uow;
            _tomadorRepository = tomadorRepository;
        }


        public async Task<ValidationResult> Adicionar(CriarSolicitacaoEmprestimo model)
        {
            var tomadorId = await _tomadorRepository.ObterIdPorUsuarioId(model.UsuarioId);

            var solicitacao = new SolicitacaoEmprestimo(model.Valor, model.Parcelas, tomadorId);

            if (!solicitacao.EhValido()) return solicitacao.Validar();

            _repository.Add(solicitacao);

            await _uow.SaveChangesAsync();

            return new ValidationResult();
        }
    }
}
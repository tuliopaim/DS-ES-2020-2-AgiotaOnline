using System.Threading.Tasks;
using EO.Application.ViewModels.InputModels.SolicitacaoEmprestimo;
using FluentValidation.Results;

namespace EO.Application.Interfaces
{
    public interface ISolicitacaoEmprestimoAppService
    {
        Task<ValidationResult> Adicionar(CriarSolicitacaoEmprestimo model);
    }
}
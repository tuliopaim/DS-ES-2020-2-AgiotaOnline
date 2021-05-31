using System.Threading.Tasks;
using EO.Application.ViewModels.InputModels.Usuario;
using EO.Domain.Entities;

namespace EO.Application.Interfaces
{
    public interface IFornecedorAppService
    {
        void Adicionar(CriarFornecedorViewModel model, int usuarioId);
        Task<EditarFornecedorViewModel> ObterParaEdicao(int usuarioId);
        Task AtualizarFornecedor(EditarFornecedorViewModel model);
    }
}
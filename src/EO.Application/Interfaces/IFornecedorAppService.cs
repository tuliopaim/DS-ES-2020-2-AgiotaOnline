using System.Threading.Tasks;
using EO.Application.ViewModels.InputModels.Usuario;

namespace EO.Application.Interfaces
{
    public interface IFornecedorAppService
    {
        Task Adicionar(CriarFornecedorViewModel model, int usuarioId);
    }
}
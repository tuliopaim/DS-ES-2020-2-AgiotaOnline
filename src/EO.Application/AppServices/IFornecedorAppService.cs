using System.Threading.Tasks;
using EO.Application.ViewModels.InputModels.Usuario;

namespace EO.Application.AppServices
{
    public interface IFornecedorAppService
    {
        Task Adicionar(CriarFornecedorViewModel model, int usuarioId);
    }
}
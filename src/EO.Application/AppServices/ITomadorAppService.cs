using System.Threading.Tasks;
using EO.Application.ViewModels.InputModels.Usuario;

namespace EO.Application.AppServices
{
    public interface ITomadorAppService
    {
        Task Adicionar(CriarTomadorViewModel model, int usuarioId);
    }
}
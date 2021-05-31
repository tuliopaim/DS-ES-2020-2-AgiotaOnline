using System.Threading.Tasks;
using EO.Application.ViewModels.InputModels.Usuario;
using EO.Domain.Entities;

namespace EO.Application.Interfaces
{
    public interface ITomadorAppService
    {
        void Adicionar(CriarTomadorViewModel model, int usuarioId);
        Task<EditarTomadorViewModel> ObterParaEdicao(int usuarioId);
        Task AtualizarTomador(EditarTomadorViewModel model);
    }
}
using EO.Application.ViewModels.InputModels.Usuario;

namespace EO.Application.Interfaces
{
    public interface ITomadorAppService
    {
        void Adicionar(CriarTomadorViewModel model, int usuarioId);
    }
}
using System.Threading.Tasks;
using EO.Application.Interfaces;
using EO.Application.ViewModels.InputModels.Usuario;

namespace EO.Application.AppServices
{
    public class TomadorAppService : ITomadorAppService
    {
        private readonly ITomadorRepository _repository;

        public TomadorAppService(ITomadorRepository repository)
        {
            _repository = repository;
        }

        public Task Adicionar(CriarTomadorViewModel model)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ITomadorAppService
    {
        Task Adicionar(CriarTomadorViewModel model);
    }
}
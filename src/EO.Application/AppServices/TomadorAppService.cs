using System.Threading.Tasks;
using EO.Application.Interfaces;
using EO.Application.ViewModels.InputModels.Usuario;
using EO.Domain.Entities;

namespace EO.Application.AppServices
{
    public class TomadorAppService : ITomadorAppService
    {
        private readonly ITomadorRepository _repository;

        public TomadorAppService(ITomadorRepository repository)
        {
            _repository = repository;
        }

        public async Task Adicionar(CriarTomadorViewModel model, int usuarioId)
        {
            var tomador = new Tomador(model.RendaMensal, usuarioId);

            _repository.Add(tomador);

            await _repository.SaveChangesAsync();
        }
    }
}
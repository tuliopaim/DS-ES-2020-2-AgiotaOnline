using EO.Application.Interfaces;
using EO.Application.ViewModels.InputModels.Usuario;
using EO.Domain.Entities;
using EO.Domain.Interfaces;

namespace EO.Application.AppServices
{
    public class TomadorAppService : ITomadorAppService
    {
        private readonly ITomadorRepository _repository;

        public TomadorAppService(ITomadorRepository repository)
        {
            _repository = repository;
        }

        public void Adicionar(CriarTomadorViewModel model, int usuarioId)
        {
            var endereco = new Endereco(
                model.Endereco.Cep,
                model.Endereco.Logradouro,
                model.Endereco.Rua,
                model.Endereco.Bairro,
                model.Endereco.Cidade,
                model.Endereco.Estado,
                model.Endereco.Pais);

            var tomador = new Tomador(model.RendaMensal, usuarioId, endereco);

            _repository.Add(tomador);
        }
    }
}
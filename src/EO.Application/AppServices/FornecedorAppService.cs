using System.Threading.Tasks;
using EO.Application.Interfaces;
using EO.Application.ViewModels.InputModels.Usuario;
using EO.Domain.Entities;
using EO.Domain.Interfaces;

namespace EO.Application.AppServices
{
    public class FornecedorAppService : IFornecedorAppService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorAppService(IFornecedorRepository repository)
        {
            _repository = repository;
        }
        
        public async Task Adicionar(CriarFornecedorViewModel model, int usuarioId)
        {
            var fornecedor = new Fornecedor(model.Capital, usuarioId);

            _repository.Add(fornecedor);

            await _repository.SaveChangesAsync();
        }
    }
}
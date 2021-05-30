using System.Threading.Tasks;
using EO.Application.Interfaces;
using EO.Application.ViewModels.InputModels.Usuario;

namespace EO.Application.AppServices
{
    public class FornecedorAppService : IFornecedorAppService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorAppService(IFornecedorRepository repository)
        {
            _repository = repository;
        }
        
        public Task Adicionar(CriarFornecedorViewModel model)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IFornecedorAppService
    {
        Task Adicionar(CriarFornecedorViewModel model);
    }
}
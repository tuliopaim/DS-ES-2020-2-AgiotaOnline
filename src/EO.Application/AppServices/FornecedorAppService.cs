using System.Threading.Tasks;
using AutoMapper;
using EO.Application.Interfaces;
using EO.Application.ViewModels.InputModels.Usuario;
using EO.Domain.Entities;
using EO.Domain.Interfaces;

namespace EO.Application.AppServices
{
    public class FornecedorAppService : IFornecedorAppService
    {
        private readonly IFornecedorRepository _repository;
        private readonly IMapper _mapper;

        public FornecedorAppService(IFornecedorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EditarFornecedorViewModel> ObterParaEdicao(int usuarioId)
        {
            var fornecedor = await _repository.ObterPorUsuarioId(usuarioId);

            return _mapper.Map<EditarFornecedorViewModel>(fornecedor);
        }

        public async Task AtualizarFornecedor(EditarFornecedorViewModel model)
        {
            var fornecedor = await _repository.ObterPorId(model.Id, true);

            fornecedor.AlterarCapital(model.Capital);
        }

        public void Adicionar(CriarFornecedorViewModel model, int usuarioId)
        {
            var fornecedor = new Fornecedor(model.Capital, usuarioId);

            _repository.Add(fornecedor);
        }
    }
}
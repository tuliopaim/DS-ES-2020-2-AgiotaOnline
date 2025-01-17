﻿using System.Threading.Tasks;
using AutoMapper;
using EO.Application.Interfaces;
using EO.Application.ViewModels.InputModels.Usuario;
using EO.Domain.Entities;
using EO.Domain.Interfaces;

namespace EO.Application.AppServices
{
    public class TomadorAppService : ITomadorAppService
    {
        private readonly ITomadorRepository _repository;
        private readonly IMapper _mapper;

        public TomadorAppService(ITomadorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EditarTomadorViewModel> ObterParaEdicao(int usuarioId)
        {
            var tomador = await _repository.ObterPorUsuarioIdComEndereco(usuarioId, true);

            return _mapper.Map<EditarTomadorViewModel>(tomador);
        }

        public async Task AtualizarTomador(EditarTomadorViewModel model)
        {
            var tomador = await _repository.ObterPorIdComEndereco(model.Id, true);
            
            tomador.AlterarRendaMensal(model.RendaMensal);

            tomador.AlterarEndereco(_mapper.Map<Endereco>(model.Endereco));
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
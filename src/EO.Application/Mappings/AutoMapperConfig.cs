using AutoMapper;
using EO.Application.ViewModels.InputModels.Usuario;
using EO.Domain.Entities;

namespace EO.Application.Mappings
{
    public class AutoMapperConfig
    {
        public MapperConfiguration GetMapperConfig()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<CriarEnderecoViewModel, Endereco>().ReverseMap();
                config.CreateMap<Usuario, EditarUsuarioViewModel>();
                config.CreateMap<Fornecedor, EditarFornecedorViewModel>();
                config.CreateMap<Tomador, EditarTomadorViewModel>();
            });
        }
    }
}
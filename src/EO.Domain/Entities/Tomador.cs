using EO.Domain.Validations;
using FluentValidation.Results;

namespace EO.Domain.Entities
{
    public class Tomador : Entidade
    {
        private readonly TomadorValidator _validador;

        protected Tomador()
        {
            _validador = new TomadorValidator();
        }

        public Tomador(decimal rendaMensal, int userId, Endereco endereco)
        {
            RendaMensal = rendaMensal;
            UserId = userId;
            Endereco = endereco;

            _validador = new TomadorValidator();
        }

        public decimal RendaMensal { get; private set; }

        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public int UserId { get; private set; }
        public Usuario Usuario { get; set; }

        public void AlterarRendaMensal(decimal novaRenda)
        {
            RendaMensal = novaRenda;
        }

        public void AlterarEndereco(Endereco novoEndereco)
        {
            if (Endereco is null) return;

            Endereco.AlterarCep(novoEndereco.Cep);
            Endereco.AlterarLogradouro(novoEndereco.Logradouro);
            Endereco.AlterarRua(novoEndereco.Rua);
            Endereco.AlterarBairro(novoEndereco.Bairro);
            Endereco.AlterarCidade(novoEndereco.Cidade);
            Endereco.AlterarEstado(novoEndereco.Estado);
            Endereco.AlterarPais(novoEndereco.Pais);
        }

        public ValidationResult Validar() => _validador.Validate(this);

        public override bool EhValido() => Validar().IsValid;
    }
}
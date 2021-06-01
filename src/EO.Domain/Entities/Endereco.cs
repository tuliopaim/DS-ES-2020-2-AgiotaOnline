using EO.Domain.Core;
using EO.Domain.Validations;
using FluentValidation.Results;

namespace EO.Domain.Entities
{
    public class Endereco : Entidade
    {
        private readonly EnderecoValidator _validador;

        protected Endereco()
        {
            _validador = new EnderecoValidator();
        }

        public Endereco(
            string cep,
            string logradouro,
            string rua,
            string bairro,
            string cidade,
            string estado,
            string pais)
        {
            Cep = cep;
            Logradouro = logradouro;
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;

            _validador = new EnderecoValidator();
        }

        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }

        public void AlterarCep(string novoCep)
        {
            Cep = Helper.SemFormatacao(novoCep);
        }
        public void AlterarLogradouro(string novoLogradouro)
        {
            Logradouro = novoLogradouro;
        }
        public void AlterarRua(string novoRua)
        {
            Rua = novoRua;
        }
        public void AlterarBairro(string novoBairro)
        {
            Bairro = novoBairro;
        }
        public void AlterarCidade(string novoCidade)
        {
            Cidade = novoCidade;
        }
        public void AlterarEstado(string novoEstado)
        {
            Estado = novoEstado;
        }
        public void AlterarPais(string novoPais)
        {
            Pais = novoPais;
        }

        public ValidationResult Validar() => _validador.Validate(this);

        public override bool EhValido() => Validar().IsValid;
    }
}
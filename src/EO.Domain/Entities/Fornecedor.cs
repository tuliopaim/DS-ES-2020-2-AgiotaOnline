using EO.Domain.Validations;
using FluentValidation.Results;

namespace EO.Domain.Entities
{
    public class Fornecedor : Entidade
    {
        private readonly FornecedorValidator _validador;

        protected Fornecedor()
        {
            _validador = new FornecedorValidator();
        }

        public Fornecedor(decimal capital, int usuarioId)
        {
            Capital = capital;
            UsuarioId = usuarioId;

            _validador = new FornecedorValidator();
        }

        public decimal Capital { get; private set; }

        public int UsuarioId { get; private set; }
        public Usuario Usuario { get; set; }

        public void AlterarCapital(decimal novoCapital)
        {
            Capital = novoCapital;
        }
        
        public ValidationResult Validar() => _validador.Validate(this);

        public override bool EhValido() => Validar().IsValid;
    }
}
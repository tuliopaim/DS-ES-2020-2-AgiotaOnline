using EO.Domain.Entities;
using FluentValidation;

namespace EO.Domain.Validations
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage(Obrigatorio("Nome"))
                .MaximumLength(200)
                .WithMessage(TamanhoMaximo("Nome", 200));

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .NotNull()
                .WithMessage(Obrigatorio("Cpf"))
                .MaximumLength(11)
                .MinimumLength(11)
                .WithMessage(TamanhoFixo("Cpf", 11));
            
            RuleFor(x => x.Telefone)
                .NotEmpty()
                .NotNull()
                .WithMessage(Obrigatorio("Telefone"))
                .MaximumLength(11)
                .MinimumLength(11)
                .WithMessage(TamanhoFixo("Telefone", 11));
        }
        
        private static string Obrigatorio(string entidade) => entidade + " obrigatório(a)!";
        private static string TamanhoMaximo(string entidade, int tamanho) 
            => $"{entidade} no máximo {tamanho} caracteres!";
        private static string TamanhoFixo(string entidade, int tamanho)
            => $"{entidade} deve conter {tamanho} caracteres!";
    }
}
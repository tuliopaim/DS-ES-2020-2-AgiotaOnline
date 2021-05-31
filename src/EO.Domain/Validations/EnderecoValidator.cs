using EO.Domain.Entities;
using FluentValidation;

namespace EO.Domain.Validations
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(x => x.Cep)
                .NotEmpty()
                .NotNull()
                .WithMessage(Obrigatorio("Cep"))
                .MaximumLength(8)
                .MinimumLength(8)
                .WithMessage(TamanhoFixo("Cep", 8));

            RuleFor(x => x.Logradouro)
                .NotEmpty()
                .NotNull()
                .WithMessage(Obrigatorio("Logradouro"))
                .MaximumLength(250)
                .WithMessage(TamanhoMaximo("Logradouro", 250));
            
            RuleFor(x => x.Rua)
                .NotEmpty()
                .NotNull()
                .WithMessage(Obrigatorio("Rua"))
                .MaximumLength(250)
                .WithMessage(TamanhoMaximo("Rua", 250));

            RuleFor(x => x.Bairro)
                .NotEmpty()
                .NotNull()
                .WithMessage(Obrigatorio("Bairro"))
                .MaximumLength(250)
                .WithMessage(TamanhoMaximo("Bairro", 250));

            RuleFor(x => x.Cidade)
                .NotEmpty()
                .NotNull()
                .WithMessage(Obrigatorio("Cidade"))
                .MaximumLength(100)
                .WithMessage(TamanhoMaximo("Cidade", 100));

            RuleFor(x => x.Estado)
                .NotEmpty()
                .NotNull()
                .WithMessage(Obrigatorio("Estado"))
                .MaximumLength(25)
                .WithMessage(TamanhoMaximo("Estado", 25));

            RuleFor(x => x.Pais)
                .NotEmpty()
                .NotNull()
                .WithMessage(Obrigatorio("Pais"))
                .MaximumLength(25)
                .WithMessage(TamanhoMaximo("Pais", 25));
        }

        private static string Obrigatorio(string entidade) => entidade + " obrigatório(a)!";
        private static string TamanhoMaximo(string entidade, int tamanho)
            => $"{entidade} no máximo {tamanho} caracteres!";
        private static string TamanhoFixo(string entidade, int tamanho)
            => $"{entidade} deve conter {tamanho} caracteres!";
    }
}
using EO.Domain.Entities;
using FluentValidation;

namespace EO.Domain.Validations
{
    public class SolicitacaoEmprestimoValidator : AbstractValidator<SolicitacaoEmprestimo>
    {
        public SolicitacaoEmprestimoValidator()
        {
            RuleFor(x => x.TomadorId)
                .NotEmpty()
                .NotNull()
                .WithMessage(Obrigatorio("TomadorId"));

            RuleFor(x => x.Valor)
                .NotEmpty()
                .NotNull()
                .WithMessage(Obrigatorio("Valor"))
                .GreaterThanOrEqualTo(1)
                .WithMessage(TamanhoMinimo("Valor", 1));

            RuleFor(x => x.Parcelas)
                .NotEmpty()
                .NotNull()
                .WithMessage(Obrigatorio("Parcelas"))
                .GreaterThanOrEqualTo(1)
                .WithMessage(TamanhoMinimo("Parcelas", 1))
                .LessThanOrEqualTo(24)
                .WithMessage(TamanhoMaximo("Parcelas", 24));
        }

        private static string Obrigatorio(string propriedade) => propriedade + " obrigatório(a)!";
        private static string TamanhoMinimo(string propriedade, int quantidade)
            => $"{propriedade} deve ser maior ou igual a {quantidade}!";
        private static string TamanhoMaximo(string propriedade, int quantidade)
            => $"{propriedade} deve ser menor ou igual {quantidade}!";
    }
}
using EO.Domain.Entities;
using FluentValidation;

namespace EO.Domain.Validations
{
    public class TomadorValidator : AbstractValidator<Tomador>
    {
        public TomadorValidator()
        {
            RuleFor(x => x.RendaMensal)
                .GreaterThanOrEqualTo(500)
                .WithMessage(MaiorOuIgual("RendaMensal", 500));

            RuleFor(x => x.Endereco)
                .SetValidator(new EnderecoValidator());
        }

        private static string MaiorOuIgual(string entidade, int quantidade)
            => $"{entidade} maior ou igual a {quantidade}!";
    }
}
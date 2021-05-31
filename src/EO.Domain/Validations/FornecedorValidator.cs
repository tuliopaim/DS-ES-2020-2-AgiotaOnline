using EO.Domain.Entities;
using FluentValidation;

namespace EO.Domain.Validations
{
    public class FornecedorValidator : AbstractValidator<Fornecedor>
    {
        public FornecedorValidator()
        {
            RuleFor(x => x.Capital)
                .GreaterThanOrEqualTo(500)
                .WithMessage(MaiorOuIgual("Capital", 500));
        }
        
        private static string MaiorOuIgual(string entidade, int quantidade)
            => $"{entidade} maior ou igual a {quantidade}!";
    }
}
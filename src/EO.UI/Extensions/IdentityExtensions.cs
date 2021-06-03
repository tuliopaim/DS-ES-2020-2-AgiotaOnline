using System.Linq;
using System.Security.Claims;
using EO.Domain.Entities;

namespace EO.UI.Extensions
{
    public static class IdentityExtensions
    {
        public static string PrimeiroNome(this ClaimsPrincipal principal)
        {
            var nome = principal.Claims.FirstOrDefault(c => c.Type == nameof(Usuario.Nome))?.Value;

            return string.IsNullOrWhiteSpace(nome)
                ? string.Empty
                : nome.Split(" ").First();
        }

        public static string NomeCompleto(this ClaimsPrincipal principal)
        {
            var nome = principal.Claims.FirstOrDefault(c => c.Type == nameof(Usuario.Nome))?.Value;

            return string.IsNullOrWhiteSpace(nome)
                ? string.Empty
                : nome;
        }
    }
}
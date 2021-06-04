using EO.Domain.Entities;
using EO.Domain.Enums;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;

namespace EO.UI.Extensions
{
    public static class RazorExtensions
    {
        public static bool SeTiverClaim(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(page.Context, claimName, claimValue);
        }

        public static bool EhFornecedor(this RazorPage page)
        {
            return CustomAuthorization.ValidarClaimsUsuario(page.Context, nameof(Usuario.Nome), TipoUsuario.Fornecedor.ToString());
        }

        public static bool EhTomador(this RazorPage page)
        {
            return CustomAuthorization.ValidarClaimsUsuario(page.Context, nameof(Usuario.Nome), TipoUsuario.Tomador.ToString());
        }

        public static string SeNaoTiverClaimDesabilite(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(page.Context, claimName, claimValue) ? "" : "disabled";
        }
        
        public static IHtmlContent SeTiverClaim(this IHtmlContent page, HttpContext context, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(context, claimName, claimValue) ? page : null;
        }
    }
}
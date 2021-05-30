using System;
using System.Linq;
using System.Security.Claims;
using EO.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace EO.UI.Controllers
{
    public class BaseController : Controller
    {
        public string ObterNomeUsuarioLogado()
        {
            return ObterClaim("Nome");
        }

        public TipoUsuario ObterTipoUsuario()
        {
            var tipoStr = ObterClaim("TipoUsuario");

            return Enum.TryParse(tipoStr, out TipoUsuario tipo)
                ? tipo
                : throw new UnauthorizedAccessException();
        }

        public int ObterIdUsuarioLogado()
        {
            var idStr = ObterClaim(ClaimTypes.NameIdentifier);

            return int.TryParse(idStr, out var id) ? id : 0;
        }

        public string ObterClaim(string type)
        {
            return User?.Claims?.FirstOrDefault(c => c.Type == type)?.Value;
        }
    }
}
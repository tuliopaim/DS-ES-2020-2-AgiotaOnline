﻿using System;
using System.Linq;
using System.Security.Claims;
using EO.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EO.UI.Controllers
{
    [Authorize]
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

        public bool EhTomador() => ObterTipoUsuario() == TipoUsuario.Tomador;
        public bool EhFornecedor() => ObterTipoUsuario() == TipoUsuario.Fornecedor;

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
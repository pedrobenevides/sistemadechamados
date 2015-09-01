using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace SistemaDeChamados.Web.Extensions
{
    public static class UsuarioExtensions
    {
        public static IEnumerable<string> ObterPermissoes(this HttpContext context)
        {
            var claims = context.User.Identity as ClaimsIdentity;

            if (claims == null)
                throw new Exception("Erro no cast das Claims do usuário");

            var acoes = claims.FindAll(x => x.Type == "Acoes");

            return acoes.Select(c => c.Value);
        }
    }
}
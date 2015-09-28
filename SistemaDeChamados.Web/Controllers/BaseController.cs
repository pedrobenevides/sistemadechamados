 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Security.Claims;
 using System.Web.Mvc;
 using SistemaDeChamados.Application.ViewModels;
 using SistemaDeChamados.Domain.Exceptions;
 using SistemaDeChamados.Domain.Services;
 using SistemaDeChamados.Web.Filters;

namespace SistemaDeChamados.Web.Controllers
{
    public class BaseController : Controller
    {
        //[OutputCache(Duration = 120)]
        [HttpGet, ChildActionOnly, PermissaoLivre]
        public ActionResult Menu()
        {
            var claims = User.Identity as ClaimsIdentity;

            if (claims == null)
                throw new ChamadosException("Erro no cast das Claims do usuário");

            var controllers = claims.FindAll(x => x.Type == "Acoes").SelectMany(c => c.Value.Replace(";","").Split('|')).Distinct();
            
            var valores = DicionarioDePermissoes(controllers.ToList());

            return PartialView(valores);
        }

        [HttpGet, ChildActionOnly, PermissaoLivre]
        public ActionResult Pagination(string controller)
        {
            return PartialView("_Pagination", new PaggingVM(controller));
        }

        private static IDictionary<string, string> DicionarioDePermissoes(IList<string> controllers)
        {
            return PossuiPermissaoParaTodoOSistema(controllers) ? 
                PerfilService.TodosAcessosDoSistema().Where(c => c.Controller != "*").ToDictionary(x => x.Controller, x => x.NomeAmigavel) : 
                PerfilService.TodosAcessosDoSistema().Where(c => controllers.Contains(c.Controller)).ToDictionary(x => x.Controller, x => x.NomeAmigavel);
        }

        private static bool PossuiPermissaoParaTodoOSistema(IList<string> controllers)
        {
            return controllers.Count() == 1 && controllers.Any(p => p == "*");
        }

        protected long UsuarioId
        {
            get
            {
                var claims = User.Identity as ClaimsIdentity;

                if (claims == null)
                    throw new Exception("Erro no cast das Claims do usuário");

                var claimId = claims.FindFirst(x => x.Type == "Id");

                return Convert.ToInt64(claimId.Value);
            }
        }
        protected string NomeUsuario
        {
            get
            {
                var claims = User.Identity as ClaimsIdentity;

                if (claims == null)
                    throw new Exception("Erro no cast das Claims do usuário");

                return claims.Name;
            }
        }
    }
}
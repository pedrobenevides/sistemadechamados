 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Security.Claims;
 using System.Web.Mvc;
 using SistemaDeChamados.Domain.Exceptions;
 using SistemaDeChamados.Domain.Services;

namespace SistemaDeChamados.Web.Controllers
{
    public class BaseController : Controller
    {
        [HttpGet, ChildActionOnly]
        public ActionResult Menu()
        {
            var claims = User.Identity as ClaimsIdentity;

            if (claims == null)
                throw new Exception("Erro no cast das Claims do usuário");

            var permissoes = claims.FindAll(x => x.Type == "Acoes").Select(c => c.Value);
            
            return PartialView(MapearPermissoes(permissoes.ToList()));
        }

        private IDictionary<string, string> MapearPermissoes(IList<string> permissoes)
        {
            var dicionarioDePermissoes = new Dictionary<string, string>();

            if (permissoes.Count() == 1 && permissoes.Any(p => p == "*;"))
                return PerfilService.TodosAcessosDoSistema().Where(c => c.Controller != "*").ToDictionary(x => x.Controller, x => x.NomeAmigavel);

            foreach (var permissao in permissoes)
            {
                var acessoVO = PerfilService.TodosAcessosDoSistema().FirstOrDefault(a => a.Controller == permissao);

                if(acessoVO == null)
                    throw new ChamadosException("Foi informado um acesso inválido no perfil do usuário logado.");

                dicionarioDePermissoes.Add(acessoVO.Controller, acessoVO.NomeAmigavel);
            }

            return dicionarioDePermissoes;
        }
    }
}
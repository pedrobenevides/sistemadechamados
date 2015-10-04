using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SistemaDeChamados.Application.Identity;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Web.Controllers
{
    public class AccountBaseController : Controller
    {
        public void IdentitySignin(UsuarioLogadoVM usuarioLogado, string providerKey = null, bool isPersistent = false)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuarioLogado.Email),
                new Claim(ClaimTypes.Name, usuarioLogado.Nome),
                new Claim(CustomClaimTypes.Id, usuarioLogado.Id.ToString())
            };

            if (usuarioLogado.Perfil != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, usuarioLogado.Perfil.Nome));
                claims.Add(new Claim(CustomClaimTypes.Acoes, usuarioLogado.Perfil.Acessos));
            }

            if (usuarioLogado.Perfil != null)
                claims.Add(new Claim(CustomClaimTypes.Setor, usuarioLogado.Setor));

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            
            AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = isPersistent,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            }, identity);
        }

        public void IdentitySignout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie,
                DefaultAuthenticationTypes.ExternalCookie);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
    }
}
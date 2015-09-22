using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SistemaDeChamados.Application.Identity;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Services.Api.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IUsuarioAppService usuarioAppService;

        public AccountController(IUsuarioAppService usuarioAppService)
        {
            this.usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public IHttpActionResult Login(LoginVM model)
        {
            try
            {
                var usuario = usuarioAppService.ObterUsuarioLogado(model);
                IdentitySignin(usuario);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public void IdentitySignin(UsuarioLogadoVM usuarioLogado, string providerKey = null, bool isPersistent = false)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuarioLogado.Email),
                new Claim(ClaimTypes.Name, usuarioLogado.Nome),
                new Claim(CustomClaimTypes.Setor, usuarioLogado.Setor),
                new Claim(CustomClaimTypes.Id, usuarioLogado.Id.ToString())
            };

            if (usuarioLogado.Perfil != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, usuarioLogado.Perfil.Nome));
                claims.Add(new Claim(CustomClaimTypes.Acoes, usuarioLogado.Perfil.Acessos));
            }

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
            get
            { return Request.GetOwinContext().Authentication; }
        }
    }
}

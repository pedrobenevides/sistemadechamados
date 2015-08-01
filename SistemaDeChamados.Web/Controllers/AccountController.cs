using System.Web.Mvc;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Web.Filters;

namespace SistemaDeChamados.Web.Controllers
{
    [PermissaoLivre]
    public class AccountController : AccountBaseController
    {
        private readonly IUsuarioAppService usuarioAppService;

        public AccountController(IUsuarioAppService usuarioAppService)
        {
            this.usuarioAppService = usuarioAppService;
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public ActionResult Login(LoginVM model, string returnUrl)
        {
            try
            {
                var usuario = usuarioAppService.ObterUsuarioLogado(model);
                
                IdentitySignin(usuario);

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("Index", "Home");
            }
            catch (ServiceException ex)
            {
                ModelState.AddModelError("ErroLogin", ex.Message);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Logoff()
        {
            IdentitySignout();
            return RedirectToAction("Login");
        }
    }
}
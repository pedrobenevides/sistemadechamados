using System.Web.Mvc;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Web.Controllers
{
    public class AccountController : AccountBaseController
    {
        private readonly IUsuarioAppService usuarioAppService;

        public AccountController(IUsuarioAppService usuarioAppService)
        {
            this.usuarioAppService = usuarioAppService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model, string returnUrl)
        {
            var usuario = usuarioAppService.ObterUsuarioLogado(model);
            
            if (usuario == null)
            {
                ModelState.AddModelError("Login Invalido","Login e/ou Senha inválidos.");
                return View();
            }
            
            IdentitySignin(usuario);

            if (string.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Logoff()
        {
            IdentitySignout();
            return RedirectToAction("Login");
        }
    }
}
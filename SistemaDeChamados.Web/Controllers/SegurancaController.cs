using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Infrastructure.Security.Configuration;

namespace SistemaDeChamados.Web.Controllers
{
    public class SegurancaController : Controller
    {
        // Definindo a instancia UserManager presente no request.
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // Definindo a instancia SignInManager presente no request.
        private ApplicationSignInManager _signInManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public SegurancaController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }


        [AllowAnonymous, HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View();

            
            //var estaAutenticado = usuarioAppService.ValidarCredenciais(model.Login, model.Senha);
            return RedirectToAction("Index", "Home");
        }
    }
}
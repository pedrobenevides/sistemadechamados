using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Web.Controllers
{
    public class SegurancaController : IdentityBaseController
    {
        [AllowAnonymous, HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await SignInManager.PasswordSignInAsync(model.Login, model.Senha, true, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                case SignInStatus.LockedOut:
                    return RedirectToAction("Login", "Seguranca");
                default:
                    ModelState.AddModelError("","Tentativa de Login inválida");
                    return View(model);
            }
        }
    }
}
using System.Web.Mvc;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Web.Controllers
{
    public class SegurancaController : Controller
    {
        private readonly IUsuarioAppService usuarioAppService;

        public SegurancaController(IUsuarioAppService usuarioAppService)
        {
            this.usuarioAppService = usuarioAppService;
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

            
            var estaAutenticado = usuarioAppService.ValidarCredenciais(model.Login, model.Senha);
            return RedirectToAction("Index", "Home");
        }
    }
}
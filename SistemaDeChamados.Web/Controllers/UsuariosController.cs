using System.Web.Mvc;
using SistemaDeChamados.Application.Interface;

namespace SistemaDeChamados.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAppService usuarioAppService;

        public UsuariosController(IUsuarioAppService usuarioAppService)
        {
            this.usuarioAppService = usuarioAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(usuarioAppService.Retrieve());
        }
    }
}
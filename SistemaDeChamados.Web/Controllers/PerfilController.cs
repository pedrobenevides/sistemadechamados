using System.Web.Mvc;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Web.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IPerfilAppService perfilAppService;

        public PerfilController(IPerfilAppService perfilAppService)
        {
            this.perfilAppService = perfilAppService;
        }

        public ActionResult Novo()
        {
            return View(new PerfilVM());
        }
    }
}
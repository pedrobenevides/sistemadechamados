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

        [HttpGet]
        public ActionResult Novo()
        {
            var model = new PerfilVM
            {
                Acoes = perfilAppService.ListarAcoesDoSistema()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Novo(PerfilVM model)
        {
            if(!ModelState.IsValid)
                return View(model);

            perfilAppService.Create(model);

            return RedirectToAction("Index");
        }
    }
}
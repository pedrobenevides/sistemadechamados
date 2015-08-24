using System.Web.Mvc;
using System.Web.SessionState;
using Ninject;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Web.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class ChamadosController : Controller
    {
        private readonly ISetorAppService setorAppService;

        [Inject]
        public ICategoriaAppService categoriaAppService { get; set; }

        public ChamadosController(ISetorAppService setorAppService)
        {
            this.setorAppService = setorAppService;
        }

        [HttpGet]
        public ActionResult Novo()
        {
            PreencherSetoresNoViewBag();
            return View(new CriacaoChamadoVM());
        }

        private void PreencherSetoresNoViewBag(long? selectedValue = null)
        {
            ViewBag.Setores = new SelectList(
                    setorAppService.ObterTodosOsSetores(),
                    "Id", "Nome", selectedValue
                );
        }
    }
}
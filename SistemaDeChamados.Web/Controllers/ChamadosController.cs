using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Ninject;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Socket;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Web.Filters;

namespace SistemaDeChamados.Web.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class ChamadosController : BaseController
    {
        private readonly ISetorAppService setorAppService;
        private readonly IChamadoAppService chamadoAppService;
        private readonly ICategoriaAppService categoriaAppService;
        private readonly ISistemaHub signalRHub;

        public ChamadosController(ISetorAppService setorAppService, 
                                    IChamadoAppService chamadoAppService, 
                                    ICategoriaAppService categoriaAppService,  
                                    ISistemaHub signalRHub)
        {
            this.setorAppService = setorAppService;
            this.chamadoAppService = chamadoAppService;
            this.categoriaAppService = categoriaAppService;
            this.signalRHub = signalRHub;
        }

        [HttpGet, ComprimirResponse]
        public ActionResult Index()
        {
            var vm = chamadoAppService.Retrieve();
            return View(vm);
        }

        [HttpGet]
        public ActionResult Novo()
        {
            PreencherSetoresNoViewBag();
            return View(new CriacaoChamadoVM());
        }

        [HttpPost]
        public async Task<ActionResult> Novo(CriacaoChamadoVM model)
        {
            if (!ModelState.IsValid)
            {
                PreencherSetoresNoViewBag();
                return View(new CriacaoChamadoVM());
            }

            model.UsuarioId = UsuarioId;
            await chamadoAppService.CreateAsync(model);
            signalRHub.Comunicar(setorAppService.ObterNomeDoSetorPorId(model.SetorId), string.Format("Foi adicionado um novo chamado pelo usuário {0}.", User.Identity.Name));

            return RedirectToAction("Index");
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
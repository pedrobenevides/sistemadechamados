using System.Threading.Tasks;
using System.Web.Mvc;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Socket;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Web.Filters;

namespace SistemaDeChamados.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IColaboradorAppService usuarioAppService;
        private readonly ISistemaHub sistemaHub;
        private readonly ISetorAppService setorAppService;
        private readonly IPerfilAppService perfilAppService;

        public UsuariosController(IColaboradorAppService usuarioAppService, ISistemaHub sistemaHub, ISetorAppService setorAppService, 
            IPerfilAppService perfilAppService)
        {
            this.usuarioAppService = usuarioAppService;
            this.sistemaHub = sistemaHub;
            this.setorAppService = setorAppService;
            this.perfilAppService = perfilAppService;
        }

        [HttpGet]
        public async Task<ActionResult> IndexAsync()
        {
            return View("Index", await usuarioAppService.ObterAsync());
        }

        [HttpGet, ComprimirResponse]
        public ActionResult Index()
        {
            return View(usuarioAppService.Obter());
        }

        [HttpGet]
        public ActionResult Novo()
        {
            PreencherTodosOsViewBags();
            return View(new ColaboradorVM());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Novo(ColaboradorVM model)
        {
            if (!ModelState.IsValid)
            {
                PreencherTodosOsViewBags();
                return View(model);
            }

            usuarioAppService.Create(model);
            sistemaHub.Comunicar(setorAppService.ObterNomeDoSetorPorId(model.SetorId), "Usuário adicionado ao sistema");

            return RedirectToAction("Index", "Usuarios");
        }

        [HttpGet]
        public ActionResult Edicao(long id)
        {
            var model = usuarioAppService.ObterParaEdicao(id);
            model.Id = id;

            PreencherTodosOsViewBags(model.SetorId, model.PerfilId);

            return View(model);
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edicao(ColaboradorEdicaoVM model)
        {
            if (!ModelState.IsValid)
            {
                PreencherTodosOsViewBags(model.SetorId, model.PerfilId);
                return View(model);
            }

            usuarioAppService.Update(model);
            return RedirectToAction("Index", "Usuarios");
        }

        [HttpGet]
        public ActionResult AlterarSenha(long id)
        {
            return View(usuarioAppService.ObterParaEdicao(id));
        }
        
        [HttpPost]
        public ActionResult AlterarSenha(ColaboradorVM model)
        {
            usuarioAppService.AtualizarSenha(model);
            return RedirectToAction("Index");
        }

        private void PreencherSetoresNoViewBag(long? selectedValue = null)
        {
            ViewBag.Setores = new SelectList(
                    setorAppService.ObterTodosOsSetores(),
                    "Id", "Nome",  selectedValue
                );
        }
        private void PreencherPerfisNoViewBag(long? selectedValue = null)
        {
            ViewBag.Perfis = new SelectList(
                    perfilAppService.Listar(),
                    "Id", "Nome",  selectedValue
                );
        }

        private void PreencherTodosOsViewBags(long?  setorSelecionado = null, long? perfilSelecionado = null)
        {
            PreencherSetoresNoViewBag();
            PreencherPerfisNoViewBag();
        }
    }
}
using System.Web.Mvc;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Socket;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAppService usuarioAppService;
        private readonly ISistemaHub sistemaHub;
        private readonly ISetorAppService setorAppService;

        public UsuariosController(IUsuarioAppService usuarioAppService, ISistemaHub sistemaHub, ISetorAppService setorAppService)
        {
            this.usuarioAppService = usuarioAppService;
            this.sistemaHub = sistemaHub;
            this.setorAppService = setorAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(usuarioAppService.ObterReadOnly());
        }

        [HttpGet]
        public ActionResult Novo()
        {
            PreencherSetoresNoViewBag();
            return View(new UsuarioVM());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Novo(UsuarioVM model)
        {
            if (!ModelState.IsValid)
            {
                PreencherSetoresNoViewBag();
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
            PreencherSetoresNoViewBag(model.SetorId);

            return View(model);
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edicao(UsuarioVM model)
        {
            if (!ModelState.IsValid)
            {
                PreencherSetoresNoViewBag();
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
        public ActionResult AlterarSenha(UsuarioVM model)
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

    }
}
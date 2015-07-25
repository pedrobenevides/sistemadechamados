using System.Web.Mvc;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;

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
            return View(usuarioAppService.ObterReadOnly());
        }

        [HttpGet]
        public ActionResult Novo()
        {
            return View(new UsuarioVM());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Novo(UsuarioVM model)
        {
            if (!ModelState.IsValid) 
                return View(model);

            usuarioAppService.Create(model);
            return RedirectToAction("Index", "Usuarios");
        }

        [HttpGet]
        public ActionResult Edicao(long id)
        {
            var model = usuarioAppService.ObterParaEdicao(id);
            model.Id = id;

            return View(model);
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edicao(UsuarioVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            usuarioAppService.Update(model);
            return RedirectToAction("Index", "Usuario");
        }
    }
}
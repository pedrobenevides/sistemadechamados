using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Infra.CrossCuting.Identity.Entities;

namespace SistemaDeChamados.Web.Controllers
{
    public class UsuariosController : IdentityBaseController
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
        public async Task<ActionResult> Novo(UsuarioVM model)
        {
            if (!ModelState.IsValid) 
                return View(model);

            var usuarioId = usuarioAppService.Create(model);

            var user = new UsuarioIdentity {Email = model.Email, UserName = model.Email, UsuarioId = usuarioId};
            var result = await UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return View();

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
        public async Task<ActionResult> Edicao(UsuarioEdicaoVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuarioIdentity = MapearUsuarioIdentity(model);
            await UserManager.UpdateAsync(usuarioIdentity);
            
            usuarioAppService.Update(model);
            return RedirectToAction("Index", "Usuarios");
        }

        private UsuarioIdentity MapearUsuarioIdentity(UsuarioEdicaoVM model)
        {
            var usuarioIdentity = UserManager.FindByEmail(model.EmailAntigo);
            usuarioIdentity.Email = model.Email;
            usuarioIdentity.UserName = model.Nome;

            return usuarioIdentity;
        }
    }
}
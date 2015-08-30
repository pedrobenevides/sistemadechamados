using System;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.SessionState;
using Ninject;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Socket;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Web.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class ChamadosController : Controller
    {
        private readonly ISetorAppService setorAppService;

        [Inject]
        public ICategoriaAppService CategoriaAppService { get; set; }
        [Inject]
        public IChamadoAppService ChamadoAppService { get; set; }
        [Inject]
        public ISistemaHub SignalRHub { get; set; }

        public ChamadosController(ISetorAppService setorAppService)
        {
            this.setorAppService = setorAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var vm = ChamadoAppService.Retrieve();
            return View(vm);
        }

        [HttpGet]
        public ActionResult Novo()
        {
            PreencherSetoresNoViewBag();
            return View(new CriacaoChamadoVM());
        }

        [HttpPost]
        public ActionResult Novo(CriacaoChamadoVM model)
        {
            if (!ModelState.IsValid)
            {
                PreencherSetoresNoViewBag();
                return View(new CriacaoChamadoVM());
            }

            model.UsuarioId = UsuarioId;
            ChamadoAppService.Create(model);
            SignalRHub.Comunicar(setorAppService.ObterNomeDoSetorPorId(model.SetorId), string.Format("Foi adicionado um novo chamado pelo usuário {0}.", User.Identity.Name));

            return RedirectToAction("Index");
        }

        private void PreencherSetoresNoViewBag(long? selectedValue = null)
        {
            ViewBag.Setores = new SelectList(
                    setorAppService.ObterTodosOsSetores(),
                    "Id", "Nome", selectedValue
                );
        }

        public long UsuarioId
        {
            get
            {
                var claims = User.Identity as ClaimsIdentity;

                if (claims == null)
                    throw new Exception("Erro no cast das Claims do usuário");

                var claimId = claims.FindFirst(x => x.Type == "Id");

                return Convert.ToInt64(claimId.Value);
            }
        }
    }
}
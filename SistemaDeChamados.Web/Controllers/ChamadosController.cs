using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.SessionState;
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
        private readonly IMensagemAppService mensagemAppService;

        public ChamadosController(ISetorAppService setorAppService, 
                                    IChamadoAppService chamadoAppService, 
                                    ICategoriaAppService categoriaAppService,  
                                    ISistemaHub signalRHub,
                                    IMensagemAppService mensagemAppService)
        {
            this.setorAppService = setorAppService;
            this.chamadoAppService = chamadoAppService;
            this.categoriaAppService = categoriaAppService;
            this.signalRHub = signalRHub;
            this.mensagemAppService = mensagemAppService;
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

            await signalRHub.Comunicar(await setorAppService.ObterNomeDoSetorPorIdAsync(model.SetorId), string.Format("Foi adicionado um novo chamado pelo usuário {0}.", User.Identity.Name));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Visualizar(long id)
        {
            var chamado = chamadoAppService.GetCompleteById(id);
            chamado.UsuarioLogadoId = UsuarioId;

            return View(chamado);
        }

        [HttpPost]
        public JsonResult NovaMensagem(MensagemVM novaMensagem)
        {
            novaMensagem.UsuarioId = UsuarioId;
            mensagemAppService.Create(novaMensagem);
            novaMensagem.NomeUsuario = NomeUsuario;
            novaMensagem.DataDeCriacao = DateTime.Now.ToString();

            var chamado = chamadoAppService.GetById(novaMensagem.ChamadoId);
            var usuarioASerNotificado = chamado.UsuarioCriadorId == UsuarioId
                ? chamadoAppService.ObterIdDoAnalistaDesseChamado(novaMensagem.ChamadoId)
                : UsuarioId;

            signalRHub.AtualizarMsgBadge(mensagemAppService.ObterNumeroDeMensagensNaoLidas(usuarioASerNotificado),
                User.Identity.Name);

            return Json(novaMensagem, JsonRequestBehavior.AllowGet);
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
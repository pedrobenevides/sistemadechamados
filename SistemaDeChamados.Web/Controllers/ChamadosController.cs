using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.SessionState;
using Ninject;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Entities;

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

        [HttpPost]
        public ActionResult NovoSegundaParte(CriacaoChamadoVM model)
        {
            PreencherCategoriasNoViewBag(model.SetorId);
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> PreencherCategorias(long setorId)
        {
            return Json(await categoriaAppService.ObterPorSetorAsync(setorId));
        }

        private void PreencherSetoresNoViewBag(long? selectedValue = null)
        {
            ViewBag.Setores = new SelectList(
                    setorAppService.ObterTodosOsSetores(),
                    "Id", "Nome", selectedValue
                );
        }
        
        private void PreencherCategoriasNoViewBag(long setorId, long? selectedValue = null)
        {
            ViewBag.Setores = new SelectList(
                    categoriaAppService.ObterPorSetor(setorId),
                    "Id", "Nome", selectedValue
                );
        }
    }
}
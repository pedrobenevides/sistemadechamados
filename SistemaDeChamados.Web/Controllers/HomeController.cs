using System.Threading.Tasks;
using System.Web.Mvc;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Web.Filters;

namespace SistemaDeChamados.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IChamadoAppService chamadoAppService;

        public HomeController(IChamadoAppService chamadoAppService)
        {
            this.chamadoAppService = chamadoAppService;
        }

        [HttpGet, PermissaoLivre]
        public async Task<ActionResult> Index()
        {
            return View(await chamadoAppService.Obter5RecentesPorUsuarioAsync(UsuarioId));
        }

        [HttpGet]
        public ViewResult NaoEncontrado()
        {
            return View();
        }
    }
}
using System.Web.Mvc;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Web.Filters;

namespace SistemaDeChamados.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChamadoAppService chamadoAppService;

        public HomeController(IChamadoAppService chamadoAppService)
        {
            this.chamadoAppService = chamadoAppService;
        }

        [HttpGet, PermissaoLivre]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult NaoEncontrado()
        {
            return View();
        }
    }
}
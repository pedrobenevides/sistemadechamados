using System.Web.Mvc;
using SistemaDeChamados.Application.Interface;

namespace SistemaDeChamados.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChamadoAppService chamadoAppService;

        public HomeController(IChamadoAppService chamadoAppService)
        {
            this.chamadoAppService = chamadoAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
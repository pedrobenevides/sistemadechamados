using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaDeChamados.Web.Controllers;

namespace SistemaDeChamados.Web.Tests.Controllers
{
    [TestClass]
    public class DadoUmBaseController
    {
        private BaseController baseController;

        public void Cenario()
        {
            baseController = new BaseController();
        }

    }
}

using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using SistemaDeChamados.Infra.CrossCuting.Identity.Configuration.IdentityManagers;

namespace SistemaDeChamados.Web.Controllers
{
    public class IdentityBaseController : Controller
    {
        public IdentityBaseController()
        {
            
        }

        // Definindo a instancia UserManager presente no request.
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // Definindo a instancia SignInManager presente no request.
        private ApplicationSignInManager _signInManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public IdentityBaseController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
    }
}
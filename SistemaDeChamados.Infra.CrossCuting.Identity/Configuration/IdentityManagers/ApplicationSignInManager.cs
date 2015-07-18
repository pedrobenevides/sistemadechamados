using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SistemaDeChamados.Infra.CrossCuting.Identity.Entities;

namespace SistemaDeChamados.Infra.CrossCuting.Identity.Configuration.IdentityManagers
{
    public class ApplicationSignInManager : SignInManager<UsuarioIdentity, string>
    {
        public ApplicationSignInManager(UserManager<UsuarioIdentity, string> userManager, IAuthenticationManager authenticationManager) : 
            base(userManager, authenticationManager) { }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}

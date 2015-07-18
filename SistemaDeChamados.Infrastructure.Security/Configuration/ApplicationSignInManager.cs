using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SistemaDeChamados.Infrastructure.Security.Models;

namespace SistemaDeChamados.Infrastructure.Security.Configuration
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(UserManager<ApplicationUser, string> userManager, IAuthenticationManager authenticationManager) 
            : base(userManager, authenticationManager) { }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SistemaDeChamados.Infra.CrossCuting.Identity.Context;
using SistemaDeChamados.Infra.CrossCuting.Identity.Entities;

namespace SistemaDeChamados.Infra.CrossCuting.Identity.Configuration.IdentityManagers
{
    public class ApplicationUserManager : UserManager<UsuarioIdentity>
    {
        public ApplicationUserManager(IUserStore<UsuarioIdentity> store) : 
            base(store) { }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<UsuarioIdentity>(context.Get<ContextoIdentity>()));

            manager.UserValidator = new UserValidator<UsuarioIdentity>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            return manager;
        }
    }
}

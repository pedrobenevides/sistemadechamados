using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using SistemaDeChamados.Infra.CrossCuting.Identity.Configuration.IdentityManagers;
using SistemaDeChamados.Infra.CrossCuting.Identity.Context;

namespace SistemaDeChamados.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(ContextoIdentity.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Seguranca/Login")
            });
        }
    }
}
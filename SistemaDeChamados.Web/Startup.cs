using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using SistemaDeChamados.Infrastructure.Security;
using SistemaDeChamados.Infrastructure.Security.Configuration;

namespace SistemaDeChamados.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(IdentityContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Seguranca/Login")
            });
        }
    }
}
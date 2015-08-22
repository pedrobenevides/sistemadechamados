using System.Web;
using System.Web.Http;

namespace SistemaDeChamados.Services.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}

using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SistemaDeChamados.Application.AutoMapper;
using SistemaDeChamados.Web.App_Start;

namespace SistemaDeChamados.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
        }
    }
}

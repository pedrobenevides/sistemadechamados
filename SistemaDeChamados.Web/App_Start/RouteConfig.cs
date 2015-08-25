using System.Web.Mvc;
using System.Web.Routing;

namespace SistemaDeChamados.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "NotFound",
                url: "NotFound/{action}",
                defaults: new { controller = "Home", action = "NaoEncontrado" });
        }
    }
}

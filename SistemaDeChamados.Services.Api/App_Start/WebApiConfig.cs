using System.Web.Http;
using SistemaDeChamados.Infra.CrossCuting.IoC;

namespace SistemaDeChamados.Services.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();

            // Web API routes
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(new Container().GetModules());
        }
    }
}

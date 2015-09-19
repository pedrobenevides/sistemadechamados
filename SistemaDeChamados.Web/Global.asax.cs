using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using SistemaDeChamados.Application.AutoMapper;

namespace SistemaDeChamados.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();

            ConfigurarDisplayMode();
            ConfigurarViewEngine();
        }

        /// <summary>
        /// Se o servidor receber uma requisição com um user-agent iPhone, o sistema vai procurar por uma view chamada nome.iphone.cshtml
        /// caso não encontre, vai procurar por nome.Mobile.cshtml.
        /// </summary>
        private static void ConfigurarDisplayMode()
        {
            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("iPhone")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf("iphone", StringComparison.OrdinalIgnoreCase) >= 0)
            });
        }

        private static void ConfigurarViewEngine()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}

using System.Web.Optimization;

namespace SistemaDeChamados.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap*"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryValidate").Include("~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/sistema").IncludeDirectory("~/Scripts/Chamados", "*.js", true));
            bundles.Add(new ScriptBundle("~/bundles/layout").IncludeDirectory("~/Scripts/Layout", "*.js", true));

            bundles.Add(new StyleBundle("~/bundles/bootstrapStyle").Include("~/Content/bootstrap*", 
                "~/Content/styles-app/customBootstrap.css",
                "~/Content/styles-app/layout.css"));
            bundles.Add(new StyleBundle("~/bundles/chamados").IncludeDirectory("~/Content/styles-app/chamados", "*.css"));
        }
    }
}
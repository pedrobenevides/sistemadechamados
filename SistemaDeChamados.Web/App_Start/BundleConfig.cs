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

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap*"));
        }
    }
}
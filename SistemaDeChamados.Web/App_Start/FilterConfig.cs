using System.Web.Mvc;
using SistemaDeChamados.Web.Filters;

namespace SistemaDeChamados.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizeAttribute());
            filters.Add(new PermissaoAcesso());
        }
    }
}
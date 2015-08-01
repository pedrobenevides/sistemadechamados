using System.Web.Mvc;
using System.Web.Routing;

namespace SistemaDeChamados.Web.Filters
{
    public class PermissaoLivre : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "Account"},
                    {"action", "Login"}
                });

                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
﻿using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Routing;

namespace SistemaDeChamados.Web.Filters
{
    public class PermissaoAcesso : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var permissaoLivreAction = filterContext.ActionDescriptor.GetCustomAttributes(typeof(PermissaoLivre), false);
            var permissaoLivreController = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(PermissaoLivre), false);

            var recursoAcessado = string.Format("{0}|{1}", filterContext.RouteData.Values["controller"], filterContext.RouteData.Values["action"]);

            if (permissaoLivreAction.Any() || permissaoLivreController.Any()) 
                return;

            //if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    filterContext.Result = new RedirectToRouteResult(MontarRota("Account", "Login"));
            //    return;
            //}

            const string permissaoAdministrador = "*;";
            var claimsIdentity = (ClaimsIdentity)filterContext.HttpContext.User.Identity;

            if (!claimsIdentity.Claims.Where(c => c.Type == "Acoes").Any(c => c.Value == permissaoAdministrador || c.Value == recursoAcessado))
            {
                filterContext.Result = new RedirectToRouteResult(MontarRota("Home", "NaoPermitido"));
                return;
            }

            base.OnActionExecuting(filterContext);
        }

        private RouteValueDictionary MontarRota(string controller, string action)
        {
            return new RouteValueDictionary
            {
                {"controller", controller},
                {"action", action}
            };
        }
    }
}
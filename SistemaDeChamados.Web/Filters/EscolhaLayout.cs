using System.Web.Mvc;

namespace SistemaDeChamados.Web.Filters
{
    /// <summary>
    /// Seleciona a _Layout de acordo com o parametro informado no Controller.
    /// </summary>
    public class EscolhaLayout : ActionFilterAttribute
    {
        private readonly string nomeDoLayout;

        public EscolhaLayout(string nomeDoLayout)
        {
            this.nomeDoLayout = nomeDoLayout;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var result = filterContext.Result as ViewResult;

            if (result != null)
                result.MasterName = nomeDoLayout;
        }
    }
}
using System.Web;
using SistemaDeChamados.Infra.Data.Interfaces;

namespace SistemaDeChamados.Infra.Data.Contexto
{
    public class ContextManager : IContextManager
    {
        public const string ContextId = "ContextManager.SistemaContext";

        public SistemaContext GetContext()
        {
            //Contexto único por Request
            if (HttpContext.Current.Items[ContextId] == null)
            {
                HttpContext.Current.Items[ContextId] = new SistemaContext();
            }

            return (SistemaContext)HttpContext.Current.Items[ContextId];
        }
    }
}

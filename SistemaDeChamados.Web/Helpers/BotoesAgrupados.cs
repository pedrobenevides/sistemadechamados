using System.Text;
using System.Web.Mvc;

namespace SistemaDeChamados.Web.Helpers
{
    public static class BotoesAgrupados
    {
        public static MvcHtmlString GroupedActionButtons(this HtmlHelper helper, string controller, long id)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(string.Format("<a href=\"{0}/Edicao/{1}\" class=\"btn btn-primary btn-sm btn-groupped\" data-toggle=\"tooltip\" data-placement=\"left\" title=\"Editar\"><i class=\"fa fa-pencil-square-o\"></i></a>",
                controller, id));
            
            stringBuilder.Append(string.Format("<a href=\"{0}/Excluir/{1}\" class=\"btn btn-danger btn-sm btn-groupped\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Excluir\"><i class=\"fa fa-trash\"></i></a>",
                controller, id));

            return MvcHtmlString.Create(stringBuilder.ToString());
        }
    }
}
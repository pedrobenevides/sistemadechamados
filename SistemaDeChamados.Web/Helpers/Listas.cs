using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace SistemaDeChamados.Web.Helpers
{
    public static class Listas
    {
        public static MvcHtmlString SideBarItens(this HtmlHelper helper, IDictionary<string, string> model)
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in model)
                stringBuilder.Append(string.Format("<li><a href=\"{0}\">{1}</a></li>", item.Key, item.Value));

            return MvcHtmlString.Create(stringBuilder.ToString());
        }
    }
}
﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Web.Helpers
{
    public static class ListaDeMensagem
    {
        public static MvcHtmlString ListaDeMensagemDoChamado(this HtmlHelper helper, IList<Mensagem> mensagens, long colaboradorId, string nomeColaborador, string nomeAnalista)
        {
            if(!mensagens.Any())
                return MvcHtmlString.Create("<p class=\"text-center\">Não existem mensagens cadastradas</p>");
            
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<ul class=\"list-group\">");

            foreach (var mensgem in mensagens)
            {
                var nome = colaboradorId == mensgem.UsuarioId ? nomeColaborador : nomeAnalista;

                stringBuilder.Append(
                    string.Format(
                        "<li class=\"list-group-item\">{0}" +
                        "   <ul class=\"list-inline\">" +
                        "       <li class=\"identificacao-usuario\">Por: " +
                        "           <span>{1}</span>" +
                        "       </li>" +
                        "   </ul>"+
                        "</li>", mensgem.Texto, nome));
            }

            return MvcHtmlString.Create(stringBuilder.ToString());
        }
    }
}
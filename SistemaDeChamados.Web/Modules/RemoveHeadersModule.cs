using System;
using System.Web;

namespace SistemaDeChamados.Web.Modules
{
    public class RemoveHeadersModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += Application_PreSendRequestHeaders;
        }

        public void Dispose()
        { }

        private static void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            var context = (HttpApplication)sender;

            if(context == null || context.Context == null) return;

            context.Context.Response.Headers.Remove("Server");
            context.Context.Response.Headers.Remove("X-AspNet-Version");
            context.Context.Response.Headers.Remove("X-AspNetMvc-Version");
        }
    }
}
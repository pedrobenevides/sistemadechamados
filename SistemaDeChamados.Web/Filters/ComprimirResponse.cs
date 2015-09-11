using System.IO.Compression;
using System.Web.Mvc;

namespace SistemaDeChamados.Web.Filters
{
    public class ComprimirResponse : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
           
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var acceptEncoding = request.Headers["Accept-Encoding"];

            if (string.IsNullOrEmpty(acceptEncoding))
                return;

            acceptEncoding = acceptEncoding.ToUpperInvariant();
            var response = filterContext.HttpContext.Response;
            
            if (acceptEncoding.Contains("GZIP"))
            {
                response.AppendHeader("Content-encoding", "gzip");
                response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
            }
            else if (acceptEncoding.Contains("DEFALTE"))
            {
                response.AppendHeader("Content-encoding", "gzip");
                response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
            }
        }
    }
}
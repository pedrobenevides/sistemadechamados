using System.Diagnostics;
using System.Web.Mvc;

namespace SistemaDeChamados.Web.Filters
{
    public class UseStopWatch : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            filterContext.Controller.ViewBag.StopWatch = stopWatch;
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var stopWatch = filterContext.Controller.ViewBag.StopWatch;
            
            if(stopWatch == null) 
                return;

            stopWatch.Stop();
            
            var tempoGasto = stopWatch.Elapsed.Seconds;
            filterContext.Controller.ViewData["tempoGasto"] = tempoGasto.ToString();

            base.OnResultExecuting(filterContext);
        }
    }
}
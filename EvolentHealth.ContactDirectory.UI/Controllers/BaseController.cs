
using EvolentHealth.ContactDirectory.Logger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EvolentHealth.ContactDirectory.UI.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILog _ILog;
        public BaseController()
        {
            _ILog = Log.GetInstance;
        }
        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    _ILog.LogException(filterContext.Exception.ToString());
        //    filterContext.ExceptionHandled = true;
        //    this.View("Error").ExecuteResult(this.ControllerContext);
        //}
    }
}

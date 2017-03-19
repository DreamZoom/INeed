using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace INeed.Authorize
{
    public class AuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AuthorizeProvider.Enable && !AuthorizeProvider.Authorize.CheckAuthorize(filterContext.RequestContext))
            {
                filterContext.Result = new JsonResult() { Data = new { result=false,message="对不起，你没有访问权限。" } };
            }
            base.OnActionExecuting(filterContext);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace INeed.Authorize
{
    public interface IAuthorize
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestContext"></param>
        /// <returns></returns>
        bool CheckAuthorize(RequestContext requestContext);

    }
}

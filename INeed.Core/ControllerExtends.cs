using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace INeed
{
    public static class ControllerExtends
    {
        public static object ToPageList<T>(this IQueryable<T> list,int page,int pagesize)
        {
            return list.ToPagedList(page, pagesize);
        }
    }
}

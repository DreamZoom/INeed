using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INeed.Web.Controllers
{
    public class PPTController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
         [Authorize]
        public ActionResult Editor()
        {
            return View();
        }

         public ActionResult Show()
         {
             return View();
         }
    }
}
using INeed.Core;
using INeed.Showing.Models;
using INeed.Showing.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace INeed.Showing
{
    public class PresentationController : ManageControllerBase<PresentationService, Presentation>
    {
        public override IQueryable<Presentation> LWhere(IQueryable<Presentation> queryable)
        {
            if (User.Identity.IsAuthenticated)
            {
                queryable = queryable.Where(m => m.Owner == User.Identity.Name);
            }
            return base.LWhere(queryable);
        }

        public override ActionResult Create(Presentation model)
        {
            if (User.Identity.IsAuthenticated)
            {
                model.Owner = User.Identity.Name;
            }
           
            return base.Create(model);
        }
        public ActionResult SavePageContent(int id, string content)
        {
            try
            {
                var model = this.Service.FindById(id);
                model.Body = content;
                Service.Update(model);

                return JsonSuccess("保存成功");
            }
            catch (Exception err)
            {
                return JsonError(err.Message);
            }
        }


        public ActionResult GetPageContent(int id)
        {
            try
            {
                var model = this.Service.FindById(id);
                return JsonSuccess("获取成功", new { content = model.Body });
            }
            catch (Exception err)
            {
                return JsonError(err.Message);
            }
        }
    }
}

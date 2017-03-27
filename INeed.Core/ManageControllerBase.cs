using INeed.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace INeed.Core
{
    [Authorize.Authorize()]
    public class ManageControllerBase<TService, TEntity> : Controller
        where TEntity : EntityBase
        where TService : EntityServiceBase<TEntity>, new()
    {
        protected TService Service { get; set; }
        protected int PageSize { get { return 20; } }
        public ManageControllerBase()
        {
            Service = new TService();          
        }

        public ActionResult JsonP(object jsonObject)
        {
            string json = JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            string callback = Request.Params["callback"];
            if (string.IsNullOrWhiteSpace(callback))
            {
                return Content(json);
            }
            return Content(string.Format("{0}({1})", callback, json));
        }

        public ActionResult JsonSuccess(string message=null,object data=null)
        {
            return JsonP(new { result = true, data = data, message = message??"成功" });
        }
        public ActionResult JsonError(string message = null, object data = null)
        {
            return JsonP(new { result = false, data = data, message = message??"失败" });
        }


        public virtual IQueryable<TEntity> LWhere(IQueryable<TEntity> queryable)
        {
            return queryable;
        }
        public virtual ActionResult List(int page=1,int pagesize=20)
        {
            var queryable = LWhere(Service.GetList().OrderBy(m => m.ID));
            var pagedlist = queryable.ToPagedList(page, pagesize);
            return JsonSuccess("列表获取成功", new { rows=pagedlist,total=pagedlist.TotalItemCount });
        }

        public virtual ActionResult Create(TEntity model)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    Service.Create(model);
                    return JsonSuccess("创建成功",model);
                }
                throw new Exception("模型验证失败");
            }
            catch (Exception err)
            {
               return JsonError(err.Message);
            }   
        }


        public virtual ActionResult Edit(TEntity model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Service.Update(model);
                    return JsonSuccess();
                }
                throw new Exception("模型验证失败");
            }
            catch (Exception err)
            {
                return JsonError(err.Message);
            }
        }

        public virtual ActionResult Delete(int Id)
        {
            try
            {
                var model = Service.Get(Id);
                if (model!=null)
                {
                    Service.Delete(model);
                    return JsonSuccess();
                }
                throw new Exception("记录未找到");
            }
            catch (Exception err)
            {
                return JsonError(err.Message);
            }
        }

        public virtual ActionResult Details(int Id)
        {
            try
            {
                var model = Service.FindById(Id);
                if (model != null)
                {
                    return JsonSuccess("获取成功",model);
                }
                throw new Exception("记录未找到");
            }
            catch (Exception err)
            {
                return JsonError(err.Message);
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="IdList"></param>
        /// <returns></returns>
        public virtual ActionResult DeleteList(int[] IdList)
        {
            try
            {
                Service.DeleteList(IdList);
                return JsonSuccess("批量删除成功");
            }
            catch (Exception err)
            {
                return JsonError(err.Message);
            }
        }

        /// <summary>
        /// 批量修改字段值
        /// </summary>
        /// <param name="IdList"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual ActionResult UpdateList(int[] IdList, string field, string value)
        {
            try
            {
                Service.UpdateList(IdList, field, value);
                return JsonSuccess("批量修改成功");
            }
            catch (Exception err)
            {
                return JsonError(err.Message);
            }
        }


    }
}

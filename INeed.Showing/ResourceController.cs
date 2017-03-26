using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INeed.Core;
using INeed.Showing.Models;
using INeed.Showing.Services;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace INeed.Showing
{
    public class ResourceController : ManageControllerBase<ResourceService, Resource>
    {

        public override IQueryable<Resource> LWhere(IQueryable<Resource> queryable)
        {
            string res_type = Request.Params["res_type"];
            if (!string.IsNullOrWhiteSpace(res_type))
            {
                queryable = queryable.Where(m => m.ResType == res_type);
            }
            return base.LWhere(queryable);
        }

        public ActionResult UploadResource(string res_type)
        {
            string resource_path = Server.MapPath("/resources");
            if (!Directory.Exists(resource_path))
            {
                Directory.CreateDirectory(resource_path);
            }
            string media_resource_path = string.Format("{0}\\{1}", resource_path, res_type);
            if (!Directory.Exists(media_resource_path))
            {
                Directory.CreateDirectory(media_resource_path);
            }

            try
            {
                HttpPostedFileBase post_file = Request.Files["resource"];
                string file_name = string.Format("{0}.{1}", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ffff"), post_file.FileName.Substring(post_file.FileName.LastIndexOf(".")));
                post_file.SaveAs(string.Format("{0}\\{1}",media_resource_path , file_name));

                string resource_url = string.Format("/resources/{0}/{1}", res_type, file_name);

                var resource = new Resource()
                {
                    ResName = post_file.FileName,
                    ResContent = resource_url,
                    IsPrivate = false,
                    CreateTime = DateTime.Now,
                    ResOwner = "system",
                    ResType = res_type
                };
                Service.Create(resource);

                return JsonSuccess("上传成功", resource);
            }
            catch
            {
                return JsonError();
            }

        }
    }
}

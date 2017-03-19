using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web.Mvc;



namespace INeed.Authorize
{
    /// <summary>
    /// 角色权限验证
    /// </summary>
    public class RoleAuthorize : IAuthorize
    {
        public static string Administrator = "Administrator";
        public bool CheckAuthorize(RequestContext requestContext)
        {
            ///如果未设置Manager，默认通过。
            if (ManagerProvider.Manager == null) return true;

            if (!ManagerProvider.Manager.CheckLogin()) return false;

            string roleName = ManagerProvider.Manager.GetRoleName();

            ///如果角色名为Administrator，具有权限
            if (roleName.Equals(Administrator)) return true;


            string controllerName = requestContext.RouteData.Values["controller"].ToString();
            string actionName = requestContext.RouteData.Values["action"].ToString();
            string areaName = requestContext.RouteData.Values["area"].ToString();

            RoleService roleService = new RoleService();
            return roleService.CheckAuthorize(roleName,areaName,controllerName,actionName,requestContext.HttpContext.Request.Params);
        }
    }
}

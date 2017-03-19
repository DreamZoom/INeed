using INeed.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INeed.Authorize
{
    public class RoleManager : IManager
    {
        public bool Login(string username, string password)
        {
             ManagerService managerService = new ManagerService();
            var manager = managerService.GetList().FirstOrDefault(m => m.UserName == username && m.Password == password);

            if (null == manager) return false;

            System.Web.HttpContext.Current.Session["manager"] = manager;
            return true;
        }

        public bool Logout()
        {
            System.Web.HttpContext.Current.Session["manager"] = null;
            return true;
        }

        public bool ChangePassword(string password, string newpassword)
        {

            if (!CheckLogin()) return false;//未登录，修改失败.

            ManagerService managerService = new ManagerService();

            var manager = System.Web.HttpContext.Current.Session["manager"] as Manager;
            if (null == manager) return false;

            if (manager.Password != password) return false;

            manager.Password = newpassword;

            if (managerService.Update(manager))
            {
                System.Web.HttpContext.Current.Session["manager"] = manager;
                return true;
            }
            return false;
        }
        public bool CheckLogin()
        {
            return System.Web.HttpContext.Current.Session["manager"] != null;
        }
        public string GetRoleName()
        {
            var manager = getManager();
            if (manager == null) return string.Empty;
            return manager.RoleName;
        }

        public string GetUserName()
        {
            var manager = getManager();
            if (manager == null) return string.Empty;
            return manager.UserName;
        }

        public object GetUser()
        {
            return System.Web.HttpContext.Current.Session["manager"];
        }


        private Manager getManager()
        {
            return GetUser() as Manager;
        }


    }
}

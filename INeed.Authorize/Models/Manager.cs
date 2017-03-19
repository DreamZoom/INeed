using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using INeed.Entity;

namespace INeed.Authorize
{
    public class Manager :EntityBase
    {
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "角色")]
        public string RoleName { get; set; }
    }
}

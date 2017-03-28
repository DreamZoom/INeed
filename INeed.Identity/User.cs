using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INeed.Identity
{
    public class User : IdentityUser
    {
        public string Email { get; set; }
    }
}

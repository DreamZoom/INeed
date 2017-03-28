using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INeed.Identity
{
    public class UserDbContext : IdentityDbContext<User>
    {
        public UserDbContext()
            : base("DefaultConnection")
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INeed.Authorize
{
    public class AuthorizeProvider
    {
        private static IAuthorize __authorize = null;
        public static IAuthorize Authorize
        {
            get
            {
                if (__authorize == null)
                {
                    __authorize = new RoleAuthorize();
                }
                return __authorize;
            }
            set
            {
                __authorize = value;
            }
        }

        public static bool Enable { get; set; }
    }
}

﻿using INeed.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INeed.Authorize
{
    public class ManagerService : EntityServiceBase<Manager>
    {
        public  bool Login(string adminName,string password)
        {
            return false;
        }
    }
}

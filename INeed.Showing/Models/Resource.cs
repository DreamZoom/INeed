using INeed.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INeed.Showing.Models
{
    public class Resource : EntityBase
    {
        public string ResName { get; set; }

        public string ResContent { get; set; }

        public string ResType { get; set; }

        public bool IsPrivate { get; set; }
        public string ResOwner { get; set; }

        
    }
}

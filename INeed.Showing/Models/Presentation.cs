using INeed.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INeed.Showing.Models
{
    public class Presentation : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Body { get; set; }

        public int Visits { get; set; }

        public string Owner { get; set; }
    }
}

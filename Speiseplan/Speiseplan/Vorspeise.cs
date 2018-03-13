using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speiseplan
{
    class Vorspeise
    {
        public Vorspeise(long vid, string vname)
        {
            VID = vid;
            VName = vname;
        }
        public long VID { get; set; }
        public string VName { get; set; }
    }
}


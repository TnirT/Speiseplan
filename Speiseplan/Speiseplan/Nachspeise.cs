using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speiseplan
{
    class Nachspeise
    {
        public Nachspeise(long nid, long nname)
        {
            NID = nid;
            NName = nname;
        }
        public long NID { get; set; }
        public long NName { get; set; }
    }
}


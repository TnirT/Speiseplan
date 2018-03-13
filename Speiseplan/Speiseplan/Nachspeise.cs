using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speiseplan
{
    class Nachspeise
    {
        public Nachspeise(long nid, string nname)
        {
            NID = nid;
            NName = nname;
        }
        public long NID { get; set; }
        public string NName { get; set; }
    }
}


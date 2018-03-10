using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speiseplan
{
    class Hauptspeise
    {

        public Hauptspeise(long hid, long hname)
        {
            HID = hid;
            HName = hname;
        }
        public long HID { get; set; }
        public long HName { get; set; }
    }
}

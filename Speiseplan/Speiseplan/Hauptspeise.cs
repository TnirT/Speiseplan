using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speiseplan
{
    class Hauptspeise
    {

        public Hauptspeise(long hid, string hname)
        {
            HID = hid;
            HName = hname;
        }
        public long HID { get; set; }
        public string HName { get; set; }
    }
}

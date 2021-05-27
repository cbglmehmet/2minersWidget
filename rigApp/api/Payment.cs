using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rigApp.api
{
    public class Payment
    {
        public int amount { get; set; }
        public int timestamp { get; set; }
        public string tx { get; set; }
    }
}

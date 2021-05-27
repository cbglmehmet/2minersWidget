using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rigApp.api
{
    public class Stats
    {
        public int balance { get; set; }
        public int blocksFound { get; set; }
        public int immature { get; set; }
        public int lastShare { get; set; }
        public int paid { get; set; }
        public bool pending { get; set; }
    }
}

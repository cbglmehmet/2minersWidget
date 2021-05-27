using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rigApp.api
{
    public class Reward
    {
        public int blockheight { get; set; }
        public int timestamp { get; set; }
        public string blockhash { get; set; }
        public int reward { get; set; }
        public float percent { get; set; }
        public bool immature { get; set; }
        public int currentLuck { get; set; }
        public bool uncle { get; set; }
    }
}

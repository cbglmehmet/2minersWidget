using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rigApp.api
{
   
        public class Root
        {
            public int currentHashrate { get; set; }
            public string currentLuck { get; set; }
            public int hashrate { get; set; }
            public int pageSize { get; set; }
            public List<Payment> payments { get; set; }
            public int paymentsTotal { get; set; }
            public List<Reward> rewards { get; set; }
            public int roundShares { get; set; }
            public List<string> shares { get; set; }
            public Stats stats { get; set; }
            public List<Sumreward> sumrewards { get; set; }
            public Workers workers { get; set; }
            public int workersOffline { get; set; }
            public int workersOnline { get; set; }
            public int workersTotal { get; set; }
            public int _24hreward { get; set; }
            public int _24hnumreward { get; set; }
        }
    
}

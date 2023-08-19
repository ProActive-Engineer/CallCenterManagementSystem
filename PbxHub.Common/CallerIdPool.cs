using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbxHub.Common
{
    public class CallerIdPool
    {
        public int poolId { get; set; }
        public int clientId { get; set; }
        public string poolName { get; set; }
        public PoolType poolType { get; set; }
    }
}

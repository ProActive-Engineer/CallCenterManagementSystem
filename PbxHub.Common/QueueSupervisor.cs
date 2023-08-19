using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbxHub.Common
{
    public class QueueSupervisor
    {
        public int queueSupervisorId { get; set; }
        public int queueId { get; set; }
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int extension { get; set; }
        public string fullName => firstName + " " + lastName;
    }
}

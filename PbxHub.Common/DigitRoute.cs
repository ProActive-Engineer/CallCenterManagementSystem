using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbxHub.Common
{
    public class DigitRoute
    {
        public string digit { get; set; }
        public int extensionLineNum { get; set; }
        public int applicationId { get; set; }
        public string destinationType { get; set; }
        public string destinationName { get; set; }
        public int destinationId { get; set; }
        public string transferMessage { get; set; }
    }
}

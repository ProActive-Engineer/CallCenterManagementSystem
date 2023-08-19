using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbxHub.Common
{
    public class OpenHours
    {
        public OpenHours()
        {
            startDay = DayOfWeek.Monday;
            endDay = DayOfWeek.Saturday;
            startTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");
            endTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");
        }
        public DayOfWeek startDay { get; set; }
        public DayOfWeek endDay { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
    }
}

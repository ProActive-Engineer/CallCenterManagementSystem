using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbxHub.Admin.App.Helpers
{
    public enum NotificationType
    {
        Success,
        Warning,
        Error
    }

    public class Notification
    {
        public string Message { get; set; }
        public DateTime NotifyTime { get; set; }
        public NotificationType Type { get; set; }
    }
}

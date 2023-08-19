
using System;

namespace PbxHub.Common
{
    public class LoginUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int authLevel { get; set; }
        public string authToken { get; set; }
        public DateTime authExpire { get; set; }
        public int currentClient { get; set; }
    }
}

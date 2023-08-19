using System;
using System.ComponentModel.DataAnnotations;

namespace PbxHub.Common
{
    public class QueueMember
    {
        [Required]
        public int queueMemberId { get; set; }
        [Required]
        public int queueId { get; set; }
        [Required]
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        [Required]
        public int extension { get; set; }
        [Required]
        public int callCount { get; set; }
        [Required]
        public int priority { get; set; }
        public int maxCallsPerDay { get; set; }
        public string fullName => firstName + " " + lastName;
    }
}

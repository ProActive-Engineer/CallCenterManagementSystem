using System;
using System.ComponentModel.DataAnnotations;

namespace PbxHub.Common
{
    public class Queue
    {
        [Required]
        public int queueId { get; set; }
        [Required]
        public string queueKey { get; set; }
        public string queueName { get; set; }
        public string appendCallerIdnameWith { get; set; }
        [Required]
        public bool allowFollowMe { get; set; }
        [Required]
        public int maxQueueWait { get; set; }
        [Required]
        public int queueTypeId { get; set; }
        public string queueTypeName { get; set; }
        public Nullable <int> overrideRingTime { get; set; }
        public bool allowCallWaiting { get; set; }
        [Required]
        public int noAnswerAdvanceTimer { get; set; }
        [Required]
        public bool wrapEnabled { get; set; }
        [Required]
        public int wrapLength { get; set; }
        public QueueMember[] members { get; set; }
        public string didStr { get; set; }
    }
}

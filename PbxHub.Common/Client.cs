using System.ComponentModel.DataAnnotations;

namespace PbxHub.Common
{
    public class Client
    {
        [Required]
        public int clientId { get; set; }
        [Required]
        public string clientName { get; set; }
        [Required]
        public string entryDate { get; set; }
        [Required]
        public string callStatusPostback { get; set; }
        [Required]
        public int maxDialerCpr { get; set; }
        [Required]
        public int timeBetweenEachDialerQueryInSeconds { get; set; }
        [Required]
        public bool dialer { get; set; }
        [Required]
        public string administratorEmail { get; set; }
        [Required]
        public string agentStatusPostback { get; set; }
        [Required]
        public string dedicatedPbx { get; set; }
        [Required]
        public int callReportingHistory { get; set; }
        [Required]
        public int callRecordingHistory { get; set; }
        [Required]
        public int parentClient { get; set; }
        [Required]
        public int advancedUsers { get; set; }
        [Required]
        public int midLevelUsers { get; set; }
        [Required]
        public int basicLevelUsers { get; set; }
        [Required]
        public bool reporting { get; set; }
        [Required]
        public bool callRecording { get; set; }
        [Required]
        public bool tts { get; set; }
        [Required]
        public bool sms { get; set; }
        [Required]
        public bool keyEnabled { get; set; }
    }
}

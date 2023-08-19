using System;
using System.ComponentModel.DataAnnotations;

namespace PbxHub.Common
{
    public class PhoneNumber
    {
        [Required]
        public int numberId { get; set; }
        [Required]
        public long phoneNumber { get; set; }
        public Nullable <long> callerId { get; set; }
        [Required]
        public string entryDate { get; set; }
        public int userId { get; set; }
        public Nullable <int> dialPlanId { get; set; }
        public Nullable <int> numberPoolNameId { get; set; }
        public string lastUsedInPoolDateTime { get; set; }
        [MaxLength(20, ErrorMessage = "The description field must be a maximum of 20 characters")]
        public string description { get; set; }        
    }
}

using System.ComponentModel.DataAnnotations;


namespace PbxHub.Common
{
    public class LoginInfo
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace PbxHub.Common
{
    public class User
    {
        public User()
        {
            Guid g = Guid.NewGuid();
            sipUserName = g.ToString();
            didList = new List<Did>();
            followMes = new List<FollowMe>();
        }

        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }        
        public string email { get; set; }
        public int authLevel { get; set; }
        public int extension { get; set; }
        public List<Did> didList { get; set; }        
        public List<FollowMe> followMes { get; set; }        
        public int ringTime { get; set; }
        public string sipUserName { get; set; }
        public string sipPassword { get; set; }
        public LicenseType licenseType { get; set; }
        public bool voiceMail { get; set; }
        public bool followMe { get; set; }
        public bool dndAllowed { get; set; }
        public bool enabled { get; set; }
        public bool recordCalls { get; set; }

        public string licenseTypeName
        {
            get
            {
                if (licenseType != null)
                {
                    return licenseType.name;
                }
                return null;
            }
            set
            {
                licenseType.name = value;
            }
        }

        public string fullName => firstName + " " + lastName;
        public string DidListStr
        {
            get
            {
                if (didList == null || didList.Count == 0)
                {
                    return "N/N";
                }
                else
                {
                    string firstNumber = didList[0].phoneNumber.ToString();
                    return firstNumber + " (" + didList.Count.ToString() + ")";
                }
            }
            set
            {

            }
        }
        public string FollowMesStr
        {
            get
            {
                if (followMes == null || followMes.Count == 0)
                {
                    return "N/N";
                }
                else
                {
                    string firstValue = followMes[0].dialString;
                    return firstValue + " (" + followMes.Count.ToString() + ")";
                }
            }
            set
            {

            }
        }

        public string followMeDelay { get; set; }
        public string otherSetting { get; set; }
        public string phoneType { get; set; }
        public string portalPassword { get; set; }
    }
}

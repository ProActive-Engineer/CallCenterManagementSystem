using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbxHub.Common
{
    public class AutoAttendant
    {
        public int id { get; set; }
        public string planName { get; set; }
        public Nullable <int> clientId { get; set; }
        public Nullable <int> type { get; set; }
        public List<Did> didList { get; set; }
        public OpenHours openHours1 { get; set; }
        public OpenHours openHours2 { get; set; }
        public OpenHours openHours3 { get; set; }
        public List<DigitRoute> routing { get; set; }
        public bool ttsForOpenGreeting { get; set; }
        public bool ttsForClosedGreeting { get; set; }
        public string openGreetingText { get; set; }
        public string closedGreetingText { get; set; }
        public string openGreetingSoundFileName { get; set; }
        public string closedGreetingSoundFileName { get; set; }
        public PbxTimeZone timeZone { get; set; }

        public string ttsOpenGreetingType => ttsForOpenGreeting ? "Text" : "Sound";
        public string ttsClosedGreetingType => ttsForClosedGreeting ? "Text" : "Sound";
        public bool timeBased => (openHours1 != null || openHours2 != null || openHours3 != null) ? true : false;

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
    }
}

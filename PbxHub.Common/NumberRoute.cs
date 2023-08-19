using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbxHub.Common
{
    public class NumberRoute
    {
        public int numberRouteId { get; set; }
        public long phoneNumber { get; set; }
        public Nullable <long> callerId { get; set; }
        public Destination destination { get; set; }
        public UserLite userFirst { get; set; }
        public Nullable <int> clientId { get; set; }
        public string assignDate { get; set; }
        public CallerIdPool callerIdPool { get; set; }
        public string lastUsedInPoolDateTime { get; set; }
        public string description { get; set; }
        public string userFullName
        {
            get
            {
                if (userFirst != null)
                {
                    return userFirst.firstName + " " + userFirst.lastName;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                userFirst.firstName = value;
            }
        }
        public string destinationType
        {
            get
            {
                if (destination != null)
                {
                    return destination.type.name;
                }
                else
                {
                    return null;
                }
            }
            set
            {

            }
        }
        public string destinationName
        {
            get
            {
                if (destination != null)
                {
                    return destination.name;
                }
                else
                {
                    return null;
                }
            }
            set
            {

            }
        }
        public string callerIdPoolName
        {
            get
            {
                if (callerIdPool != null)
                {
                    return callerIdPool.poolName;
                }
                else
                {
                    return null;
                }
            }
            set
            {

            }
        }
    }
}

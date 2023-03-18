using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Data.Models
{
    public class Subscriber
    {
        public Int64 SubscriberMasterId { get; set; }
        public string SubscroberCode { get; set; }
        public string SubscriberName { get; set; }
        public string SubscriberAddress { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Boolean IsStatus { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Int64 ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}

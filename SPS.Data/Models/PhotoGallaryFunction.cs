
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Data.Models
{
    public class PhotoGallaryFunction
    {
        public Int64 FunctionId { get; set; }

         public Int64 SubscriberMasterId { get; set; }
        public string FunctionName { get; set; }
        public string FunctionDescription { get; set; }

        public Boolean IsStatus { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Int64 ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace SPS.Data.Models
{
    public partial class CategoryDetail
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? CategoryDesc { get; set; }
        public bool? CategoryStatus { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

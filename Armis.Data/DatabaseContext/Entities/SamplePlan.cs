using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SamplePlan
    {
        public SamplePlan()
        {
            Part = new HashSet<Part>();
        }

        public string SamplePlanCd { get; set; }
        public string Name { get; set; }
        public int? CustId { get; set; }
        public int? TestId { get; set; }
        public int FromQty { get; set; }
        public int ThruQty { get; set; }
        public int SampleQty { get; set; }
        public int? RejectAcceptQty { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual TestHead Test { get; set; }
        public virtual ICollection<Part> Part { get; set; }
    }
}

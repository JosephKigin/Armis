using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SamplePlanHead
    {
        public SamplePlanHead()
        {
            Part = new HashSet<Part>();
            SamplePlanLevel = new HashSet<SamplePlanLevel>();
            SpecificationNadCapSamplePlanNavigation = new HashSet<Specification>();
            SpecificationSamplePlanNavigation = new HashSet<Specification>();
        }

        public int SamplePlanId { get; set; }
        public string PlanName { get; set; }
        public string Description { get; set; }
        public int? CustId { get; set; }
        public string TestCd { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual TestType TestCdNavigation { get; set; }
        public virtual ICollection<Part> Part { get; set; }
        public virtual ICollection<SamplePlanLevel> SamplePlanLevel { get; set; }
        public virtual ICollection<Specification> SpecificationNadCapSamplePlanNavigation { get; set; }
        public virtual ICollection<Specification> SpecificationSamplePlanNavigation { get; set; }
    }
}

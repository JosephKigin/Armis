using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SamplePlanHead
    {
        public SamplePlanHead()
        {
            PartRevision = new HashSet<PartRevision>();
            SamplePlanLevel = new HashSet<SamplePlanLevel>();
            SpecificationRevisionNadCapSamplePlanNavigation = new HashSet<SpecificationRevision>();
            SpecificationRevisionSamplePlanNavigation = new HashSet<SpecificationRevision>();
        }

        public int SamplePlanId { get; set; }
        public string PlanName { get; set; }
        public string Description { get; set; }
        public int? CustId { get; set; }
        public string TestCd { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual TestType TestCdNavigation { get; set; }
        public virtual ICollection<PartRevision> PartRevision { get; set; }
        public virtual ICollection<SamplePlanLevel> SamplePlanLevel { get; set; }
        public virtual ICollection<SpecificationRevision> SpecificationRevisionNadCapSamplePlanNavigation { get; set; }
        public virtual ICollection<SpecificationRevision> SpecificationRevisionSamplePlanNavigation { get; set; }
    }
}

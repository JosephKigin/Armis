using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SamplePlanHead
    {
        public SamplePlanHead()
        {
            SamplePlanLevel = new HashSet<SamplePlanLevel>();
            SpecificationRevision = new HashSet<SpecificationRevision>();
        }

        public int SamplePlanId { get; set; }
        public string PlanName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SamplePlanLevel> SamplePlanLevel { get; set; }
        public virtual ICollection<SpecificationRevision> SpecificationRevision { get; set; }
    }
}

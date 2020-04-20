using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SamplePlanLevel
    {
        public SamplePlanLevel()
        {
            SamplePlanReject = new HashSet<SamplePlanReject>();
        }

        public int SamplePlanId { get; set; }
        public int SamplePlanLevelId { get; set; }
        public int FromQty { get; set; }
        public int ToQty { get; set; }

        public virtual SamplePlanHead SamplePlan { get; set; }
        public virtual ICollection<SamplePlanReject> SamplePlanReject { get; set; }
    }
}

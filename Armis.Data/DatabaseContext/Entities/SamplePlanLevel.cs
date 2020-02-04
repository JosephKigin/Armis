using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SamplePlanLevel
    {
        public int SamplePlanId { get; set; }
        public int SamplePlanLevelId { get; set; }
        public int FromQty { get; set; }
        public int ThruQty { get; set; }
        public int SampleQty { get; set; }
        public int RejectAcceptQty { get; set; }

        public virtual SamplePlanHead SamplePlan { get; set; }
    }
}

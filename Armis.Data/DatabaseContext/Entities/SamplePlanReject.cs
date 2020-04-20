using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SamplePlanReject
    {
        public int SamplePlanId { get; set; }
        public int SamplePlanLevelId { get; set; }
        public short InspectTestId { get; set; }
        public int SampleQty { get; set; }
        public int RejectAllowQty { get; set; }

        public virtual InspectTestType InspectTest { get; set; }
        public virtual SamplePlanLevel SamplePlan { get; set; }
    }
}

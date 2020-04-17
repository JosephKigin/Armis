using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class InspectTestType
    {
        public InspectTestType()
        {
            SamplePlanReject = new HashSet<SamplePlanReject>();
        }

        public short InspectTestId { get; set; }
        public string TestCode { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SamplePlanReject> SamplePlanReject { get; set; }
    }
}

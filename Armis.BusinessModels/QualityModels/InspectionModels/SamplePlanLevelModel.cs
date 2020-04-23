using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.QualityModels.Spec
{
    public class SamplePlanLevelModel
    {
        public int SamplePlanId { get; set; }
        public int SamplePlanLevelId { get; set; }
        public int FromQty { get; set; }
        public int ToQty { get; set; }

        public IEnumerable<SamplePlanRejectModel> SamplePlanRejectModels { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.QualityModels.InspectionModels
{
    public class SamplePlanModel
    {
        public int SamplePlanId { get; set; }
        public string PlanName { get; set; }
        public string Description { get; set; }

        public IEnumerable<SamplePlanLevelModel> SamplePlanLevelModels { get; set; }
    }
}

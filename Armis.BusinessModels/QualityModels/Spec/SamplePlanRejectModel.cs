using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.QualityModels.Spec
{
    public class SamplePlanRejectModel
    {
        public int SamplePlanId { get; set; }
        public int SamplePlanLevelId { get; set; }
        public short InspectTestTypeId { get; set; }
        public int SampleQty { get; set; }
        public int RejectAllowQty { get; set; }

        public InspectTestTypeModel InspectioneTestType { get; set; }
    }
}

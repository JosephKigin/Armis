using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.QualityModels.Spec
{
    public class SpecRevModel
    {
        public int SpecId { get; set; }
        public string SpecCode { get; set; }
        public short InternalRev { get; set; }
        public string Description { get; set; }
        public string ExternalRev { get; set; }
        public int? SamplePlanId { get; set; }
        public int EmployeeNumber { get; set; } //TODO: this could be an entire employee model but for now I am just keeping it as a number because all the employee information isn't needed when the spec rev is pulled.
        public DateTime DateCreated { get; set; }
        public TimeSpan TimeCreated { get; set; }

        public IEnumerable<SpecSubLevelModel> SubLevels { get; set; }
        public SamplePlanModel SamplePlan { get; set; }
    }
}

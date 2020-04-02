using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Specification
    {
        public Specification()
        {
            Certification = new HashSet<Certification>();
            DeptSpec = new HashSet<DeptSpec>();
            SpecProcessAssign = new HashSet<SpecProcessAssign>();
            SpecSubLevel = new HashSet<SpecSubLevel>();
        }

        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public string SpecCode { get; set; }
        public string Description { get; set; }
        public string ExternalRev { get; set; }
        public int? SamplePlan { get; set; }
        public int? NadCapSamplePlan { get; set; }

        public virtual SamplePlanHead NadCapSamplePlanNavigation { get; set; }
        public virtual SamplePlanHead SamplePlanNavigation { get; set; }
        public virtual ICollection<Certification> Certification { get; set; }
        public virtual ICollection<DeptSpec> DeptSpec { get; set; }
        public virtual ICollection<SpecProcessAssign> SpecProcessAssign { get; set; }
        public virtual ICollection<SpecSubLevel> SpecSubLevel { get; set; }
    }
}

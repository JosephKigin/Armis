using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SpecificationRevision
    {
        public SpecificationRevision()
        {
            DeptSpec = new HashSet<DeptSpec>();
            SpecProcessAssign = new HashSet<SpecProcessAssign>();
            SpecSubLevel = new HashSet<SpecSubLevel>();
        }

        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public string Description { get; set; }
        public string ExternalRev { get; set; }
        public int? SamplePlan { get; set; }
        public int CreatedByEmp { get; set; }
        public DateTime DateCreated { get; set; }
        public TimeSpan TimeCreated { get; set; }

        public virtual Employee CreatedByEmpNavigation { get; set; }
        public virtual SamplePlanHead SamplePlanNavigation { get; set; }
        public virtual Specification Spec { get; set; }
        public virtual ICollection<DeptSpec> DeptSpec { get; set; }
        public virtual ICollection<SpecProcessAssign> SpecProcessAssign { get; set; }
        public virtual ICollection<SpecSubLevel> SpecSubLevel { get; set; }
    }
}

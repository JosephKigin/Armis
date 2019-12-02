using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SubOpRevision
    {
        public SubOpRevision()
        {
            ProcessSubOprList = new HashSet<ProcessSubOprList>();
            ProcessVarOverride = new HashSet<ProcessVarOverride>();
            SubOpStepList = new HashSet<SubOpStepList>();
        }

        public int SubOpRevId { get; set; }
        public int SubOpId { get; set; }
        public short CreatedByEmp { get; set; }
        public DateTime DateCreated { get; set; }
        public TimeSpan TimeCreated { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }

        public virtual Employee CreatedByEmpNavigation { get; set; }
        public virtual Status StatusNavigation { get; set; }
        public virtual SubOperation SubOp { get; set; }
        public virtual ICollection<ProcessSubOprList> ProcessSubOprList { get; set; }
        public virtual ICollection<ProcessVarOverride> ProcessVarOverride { get; set; }
        public virtual ICollection<SubOpStepList> SubOpStepList { get; set; }
    }
}

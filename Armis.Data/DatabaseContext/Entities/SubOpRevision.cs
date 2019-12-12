using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SubOpRevision
    {
        public SubOpRevision()
        {
            ProcessSubOprSeq = new HashSet<ProcessSubOprSeq>();
            ProcessVarOverride = new HashSet<ProcessVarOverride>();
            SubOpStepSeq = new HashSet<SubOpStepSeq>();
        }

        public int SubOpId { get; set; }
        public int SubOpRevId { get; set; }
        public short CreatedByEmp { get; set; }
        public DateTime DateCreated { get; set; }
        public TimeSpan TimeCreated { get; set; }
        public string Comments { get; set; }
        public string RevStatusCd { get; set; }

        public virtual Employee CreatedByEmpNavigation { get; set; }
        public virtual RevisionStatus RevStatusCdNavigation { get; set; }
        public virtual SubOperation SubOp { get; set; }
        public virtual ICollection<ProcessSubOprSeq> ProcessSubOprSeq { get; set; }
        public virtual ICollection<ProcessVarOverride> ProcessVarOverride { get; set; }
        public virtual ICollection<SubOpStepSeq> SubOpStepSeq { get; set; }
    }
}

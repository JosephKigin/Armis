using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ProcessRevision
    {
        public ProcessRevision()
        {
            OrderHead = new HashSet<OrderHead>();
            ProcessSubOprSeq = new HashSet<ProcessSubOprSeq>();
            ProcessVarOverride = new HashSet<ProcessVarOverride>();
        }

        public int ProcessId { get; set; }
        public int ProcessRevId { get; set; }
        public short CreatedByEmp { get; set; }
        public DateTime DateCreated { get; set; }
        public TimeSpan TimeCreated { get; set; }
        public string RevStatusCd { get; set; }
        public int? DueDays { get; set; }
        public string Notes { get; set; }

        public virtual Employee CreatedByEmpNavigation { get; set; }
        public virtual Process Process { get; set; }
        public virtual RevisionStatus RevStatusCdNavigation { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
        public virtual ICollection<ProcessSubOprSeq> ProcessSubOprSeq { get; set; }
        public virtual ICollection<ProcessVarOverride> ProcessVarOverride { get; set; }
    }
}

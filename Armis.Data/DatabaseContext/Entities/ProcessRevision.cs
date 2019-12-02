using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ProcessRevision
    {
        public ProcessRevision()
        {
            OrderHead = new HashSet<OrderHead>();
            ProcessSubOprList = new HashSet<ProcessSubOprList>();
            ProcessVarOverride = new HashSet<ProcessVarOverride>();
        }

        public int ProcessRevId { get; set; }
        public int ProcessId { get; set; }
        public short CreatedByEmp { get; set; }
        public DateTime DateCreated { get; set; }
        public TimeSpan TimeCreated { get; set; }
        public string Status { get; set; }
        public int? DueDays { get; set; }
        public string Notes { get; set; }

        public virtual Employee CreatedByEmpNavigation { get; set; }
        public virtual Process Process { get; set; }
        public virtual Status StatusNavigation { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
        public virtual ICollection<ProcessSubOprList> ProcessSubOprList { get; set; }
        public virtual ICollection<ProcessVarOverride> ProcessVarOverride { get; set; }
    }
}

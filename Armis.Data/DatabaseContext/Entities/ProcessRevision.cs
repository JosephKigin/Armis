using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ProcessRevision
    {
        public ProcessRevision()
        {
            PartTran = new HashSet<PartTran>();
            ProcessStepSeq = new HashSet<ProcessStepSeq>();
            SpecProcessAssign = new HashSet<SpecProcessAssign>();
        }

        public int ProcessId { get; set; }
        public int ProcessRevId { get; set; }
        public int CreatedByEmp { get; set; }
        public DateTime DateCreated { get; set; }
        public TimeSpan TimeCreated { get; set; }
        public byte RevStatusId { get; set; }
        public string Comments { get; set; }

        public virtual Employee CreatedByEmpNavigation { get; set; }
        public virtual Process Process { get; set; }
        public virtual RevisionStatus RevStatus { get; set; }
        public virtual ICollection<PartTran> PartTran { get; set; }
        public virtual ICollection<ProcessStepSeq> ProcessStepSeq { get; set; }
        public virtual ICollection<SpecProcessAssign> SpecProcessAssign { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SpecProcessAssign
    {
        public SpecProcessAssign()
        {
            OrderHead = new HashSet<OrderHead>();
            SpecProcessAssignHist = new HashSet<SpecProcessAssignHist>();
            SpecProcessAssignOption = new HashSet<SpecProcessAssignOption>();
        }

        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public int SpecAssignId { get; set; }
        public int ProcessId { get; set; }
        public int ProcessRevId { get; set; }
        public bool Inactive { get; set; }
        public bool ReviewNeeded { get; set; }
        public int? Customer { get; set; }

        public virtual Customer CustomerNavigation { get; set; }
        public virtual ProcessRevision Process { get; set; }
        public virtual SpecificationRevision Spec { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
        public virtual ICollection<SpecProcessAssignHist> SpecProcessAssignHist { get; set; }
        public virtual ICollection<SpecProcessAssignOption> SpecProcessAssignOption { get; set; }
    }
}

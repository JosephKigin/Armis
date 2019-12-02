using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Process
    {
        public Process()
        {
            PartHist = new HashSet<PartHist>();
            ProcessRevision = new HashSet<ProcessRevision>();
        }

        public int ProcessId { get; set; }
        public string Name { get; set; }
        public int? CustId { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual ICollection<PartHist> PartHist { get; set; }
        public virtual ICollection<ProcessRevision> ProcessRevision { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Process
    {
        public Process()
        {
            ProcessRevision = new HashSet<ProcessRevision>();
        }

        public int ProcessId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProcessRevision> ProcessRevision { get; set; }
    }
}

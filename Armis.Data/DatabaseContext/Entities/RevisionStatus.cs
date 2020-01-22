using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class RevisionStatus
    {
        public RevisionStatus()
        {
            ProcessRevision = new HashSet<ProcessRevision>();
        }

        public string RevStatusCd { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProcessRevision> ProcessRevision { get; set; }
    }
}

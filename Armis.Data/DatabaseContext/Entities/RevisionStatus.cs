using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class RevisionStatus
    {
        public RevisionStatus()
        {
            ProcessRevision = new HashSet<ProcessRevision>();
            Step = new HashSet<Step>();
            SubOpRevision = new HashSet<SubOpRevision>();
        }

        public string RevStatusCd { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProcessRevision> ProcessRevision { get; set; }
        public virtual ICollection<Step> Step { get; set; }
        public virtual ICollection<SubOpRevision> SubOpRevision { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class PartSpecProcessAssign
    {
        public int PartId { get; set; }
        public short PartRevId { get; set; }
        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public short SpecAssignId { get; set; }
        public DateTime LastUsedDate { get; set; }

        public virtual Part Part { get; set; }
        public virtual SpecProcessAssign Spec { get; set; }
    }
}

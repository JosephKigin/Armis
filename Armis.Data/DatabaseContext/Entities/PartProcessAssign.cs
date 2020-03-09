using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class PartProcessAssign
    {
        public int PartId { get; set; }
        public int SpecProcessAssignId { get; set; }
        public bool Inactive { get; set; }
        public DateTime LastUsedDate { get; set; }

        public virtual Part Part { get; set; }
        public virtual SpecProcessAssign SpecProcessAssign { get; set; }
    }
}

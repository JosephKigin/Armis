using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Part
    {
        public Part()
        {
            PartRevision = new HashSet<PartRevision>();
        }

        public int PartId { get; set; }
        public string PartName { get; set; }
        public bool Inactive { get; set; }

        public virtual ICollection<PartRevision> PartRevision { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class PartRev
    {
        public PartRev()
        {
            Part = new HashSet<Part>();
        }

        public int PartId { get; set; }
        public int PartRevId { get; set; }

        public virtual Part PartNavigation { get; set; }
        public virtual ICollection<Part> Part { get; set; }
    }
}

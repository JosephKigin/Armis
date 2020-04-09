using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Specification
    {
        public Specification()
        {
            SpecificationRevision = new HashSet<SpecificationRevision>();
        }

        public int SpecId { get; set; }
        public string SpecCode { get; set; }

        public virtual ICollection<SpecificationRevision> SpecificationRevision { get; set; }
    }
}

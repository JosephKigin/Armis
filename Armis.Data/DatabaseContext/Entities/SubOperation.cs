using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SubOperation
    {
        public SubOperation()
        {
            SubOpRevision = new HashSet<SubOpRevision>();
        }

        public int SubOpId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubOpRevision> SubOpRevision { get; set; }
    }
}

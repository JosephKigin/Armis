using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OperationGroup
    {
        public OperationGroup()
        {
            Operation = new HashSet<Operation>();
        }

        public string OperationGroupCd { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Operation> Operation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class TranType
    {
        public TranType()
        {
            PartTran = new HashSet<PartTran>();
        }

        public short TranTypeId { get; set; }
        public string TranCode { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PartTran> PartTran { get; set; }
    }
}

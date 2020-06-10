using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class CustomerPart
    {
        public int CustId { get; set; }
        public int PartId { get; set; }
        public DateTime LastUsedDate { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual Part Part { get; set; }
    }
}

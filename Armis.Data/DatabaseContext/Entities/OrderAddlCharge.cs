using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OrderAddlCharge
    {
        public int OrderId { get; set; }
        public byte ChargeNumber { get; set; }
        public short? ChargeId { get; set; }
        public decimal? Amount { get; set; }

        public virtual AddlCharge Charge { get; set; }
        public virtual OrderHead Order { get; set; }
    }
}

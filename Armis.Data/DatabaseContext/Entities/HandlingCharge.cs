using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class HandlingCharge
    {
        public HandlingCharge()
        {
            OrderHead = new HashSet<OrderHead>();
        }

        public string HandlingChargeCd { get; set; }
        public string ChargeDescription { get; set; }
        public decimal Charge { get; set; }

        public virtual ICollection<OrderHead> OrderHead { get; set; }
    }
}

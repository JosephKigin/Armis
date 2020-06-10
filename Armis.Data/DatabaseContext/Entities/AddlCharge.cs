using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class AddlCharge
    {
        public AddlCharge()
        {
            OrderAddlCharge = new HashSet<OrderAddlCharge>();
        }

        public short ChargeId { get; set; }
        public string Code { get; set; }
        public short ChargeTypeId { get; set; }
        public decimal DefaultAmount { get; set; }

        public virtual AddlChargeType ChargeType { get; set; }
        public virtual ICollection<OrderAddlCharge> OrderAddlCharge { get; set; }
    }
}

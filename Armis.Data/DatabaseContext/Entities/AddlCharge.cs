using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class AddlCharge
    {
        public AddlCharge()
        {
            OrderHeadHandlingCharge = new HashSet<OrderHead>();
            OrderHeadMiscCharge = new HashSet<OrderHead>();
            OrderHeadShipCharge = new HashSet<OrderHead>();
        }

        public short ChargeId { get; set; }
        public string Code { get; set; }
        public short ChargeTypeId { get; set; }
        public decimal Amount { get; set; }

        public virtual AddlChargeType ChargeType { get; set; }
        public virtual ICollection<OrderHead> OrderHeadHandlingCharge { get; set; }
        public virtual ICollection<OrderHead> OrderHeadMiscCharge { get; set; }
        public virtual ICollection<OrderHead> OrderHeadShipCharge { get; set; }
    }
}

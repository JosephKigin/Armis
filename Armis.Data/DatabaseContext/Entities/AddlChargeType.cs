using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class AddlChargeType
    {
        public AddlChargeType()
        {
            AddlCharge = new HashSet<AddlCharge>();
        }

        public short ChargeTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AddlCharge> AddlCharge { get; set; }
    }
}

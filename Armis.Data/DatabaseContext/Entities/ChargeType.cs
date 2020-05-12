using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ChargeType
    {
        public ChargeType()
        {
            Charge = new HashSet<Charge>();
        }

        public short ChargeTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Charge> Charge { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ShipViaTypeCode
    {
        public ShipViaTypeCode()
        {
            ShipVia = new HashSet<ShipVia>();
        }

        public string SvtypeCd { get; set; }

        public virtual ICollection<ShipVia> ShipVia { get; set; }
    }
}

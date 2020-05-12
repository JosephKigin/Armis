using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ShipViaTypeCode
    {
        public ShipViaTypeCode()
        {
            ShipViaCode = new HashSet<ShipViaCode>();
        }

        public byte ShipViaTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ShipViaCode> ShipViaCode { get; set; }
    }
}

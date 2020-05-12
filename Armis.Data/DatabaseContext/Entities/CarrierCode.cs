using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class CarrierCode
    {
        public CarrierCode()
        {
            ShipAccount = new HashSet<ShipAccount>();
            ShipViaCode = new HashSet<ShipViaCode>();
        }

        public byte CarrierId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OurAcctNum { get; set; }
        public string Type { get; set; }

        public virtual ICollection<ShipAccount> ShipAccount { get; set; }
        public virtual ICollection<ShipViaCode> ShipViaCode { get; set; }
    }
}

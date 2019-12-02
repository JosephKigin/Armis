using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Carrier
    {
        public Carrier()
        {
            ShipAccount = new HashSet<ShipAccount>();
            ShipVia = new HashSet<ShipVia>();
        }

        public string CarrierCd { get; set; }
        public string Name { get; set; }
        public string OurAccount { get; set; }
        public string Type { get; set; }

        public virtual ICollection<ShipAccount> ShipAccount { get; set; }
        public virtual ICollection<ShipVia> ShipVia { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ShipVia
    {
        public ShipVia()
        {
            Customer = new HashSet<Customer>();
            OrderHead = new HashSet<OrderHead>();
            ShipTo = new HashSet<ShipTo>();
        }

        public string ShipViaCd { get; set; }
        public string Description { get; set; }
        public string SvtypeCd { get; set; }
        public string CarrierCd { get; set; }

        public virtual Carrier CarrierCdNavigation { get; set; }
        public virtual ShipViaTypeCode SvtypeCdNavigation { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
        public virtual ICollection<ShipTo> ShipTo { get; set; }
    }
}

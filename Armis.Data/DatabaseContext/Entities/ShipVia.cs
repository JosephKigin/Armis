using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ShipVia
    {
        public ShipVia()
        {
            CustomerDefaultShipViaCdNavigation = new HashSet<Customer>();
            CustomerDefaultShipViaNavigation = new HashSet<Customer>();
            OrderHead = new HashSet<OrderHead>();
        }

        public string ShipViaCd { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string CarrierCd { get; set; }

        public virtual Carrier CarrierCdNavigation { get; set; }
        public virtual ICollection<Customer> CustomerDefaultShipViaCdNavigation { get; set; }
        public virtual ICollection<Customer> CustomerDefaultShipViaNavigation { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ShipViaCode
    {
        public ShipViaCode()
        {
            Customer = new HashSet<Customer>();
            OrderHead = new HashSet<OrderHead>();
            ShipTo = new HashSet<ShipTo>();
        }

        public short ShipViaId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public byte ShipViaTypeId { get; set; }
        public byte CarrierId { get; set; }

        public virtual CarrierCode Carrier { get; set; }
        public virtual ShipViaTypeCode ShipViaType { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
        public virtual ICollection<ShipTo> ShipTo { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ShipAccount
    {
        public ShipAccount()
        {
            Customer = new HashSet<Customer>();
        }

        public short ShipAccountId { get; set; }
        public int CustId { get; set; }
        public string AccountNum { get; set; }
        public string Comments { get; set; }
        public byte? CarrierId { get; set; }

        public virtual CarrierCode Carrier { get; set; }
        public virtual Customer Cust { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
    }
}

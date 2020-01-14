using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ShipTo
    {
        public ShipTo()
        {
            Contact = new HashSet<Contact>();
            Customer = new HashSet<Customer>();
        }

        public int CustId { get; set; }
        public short ShipToId { get; set; }
        public bool Inactive { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string DefaultShipVia { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNum { get; set; }
        public string FaxNum { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual ShipVia DefaultShipViaNavigation { get; set; }
        public virtual ICollection<Contact> Contact { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
    }
}

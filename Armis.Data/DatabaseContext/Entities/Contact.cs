using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Contact
    {
        public Contact()
        {
            CustContNotify = new HashSet<CustContNotify>();
            Customer = new HashSet<Customer>();
            Memo = new HashSet<Memo>();
        }

        public int ContactId { get; set; }
        public int? CustId { get; set; }
        public short? ShipToId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNum { get; set; }
        public string FaxNum { get; set; }
        public short? TitleId { get; set; }
        public bool? Inactive { get; set; }
        public string Comments { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual ShipTo ShipTo { get; set; }
        public virtual ContactTitle Title { get; set; }
        public virtual ICollection<CustContNotify> CustContNotify { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Memo> Memo { get; set; }
    }
}

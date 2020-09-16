using Armis.BusinessModels.ShippingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.CustomerModels
{
    public class ContactModel
    {
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
        public ContactTitleModel ContactTitle { get; set; }
        public ShipToModel ShipTo { get; set; }
        //public IEnumerable<CustContNotifyModel> CustContNotify {get; set} <---- This will be used when the customer contact notify table is more fleshed out.  It will be used to tell the system when to send off a notification to the contact. e.g. packing slip is created, job done, job shipped, etc...
    }
}

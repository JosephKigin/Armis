using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ShippingModels
{
    public class ShipToModel
    {
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
        public short? DefaultShipViaId { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNum { get; set; }
        public string FaxNum { get; set; }

        public ShipViaModel ShipViaCode { get; set; }
    }
}

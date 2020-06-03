using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.CustomerModels
{
    public class BillToModel
    {
        public int CustId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string PhoneNum { get; set; }
        public string FaxNum { get; set; }
    }
}

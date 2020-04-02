using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OrderShipTo
    {
        public int OrderId { get; set; }
        public string Stattn { get; set; }
        public string Stname { get; set; }
        public string Staddress1 { get; set; }
        public string Staddress2 { get; set; }
        public string Staddress3 { get; set; }
        public string Stcity { get; set; }
        public string Ststate { get; set; }
        public string Stzip { get; set; }
        public string Stphone { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ShippingModels
{
    public class CarrierCodeModel
    {
        public byte CarrierId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OurAcctNum { get; set; }
        public string Type { get; set; }
    }
}

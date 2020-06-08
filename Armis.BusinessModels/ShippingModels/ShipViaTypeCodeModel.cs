using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ShippingModels
{
    public class ShipViaTypeCodeModel
    {
        public byte ShipViaTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}

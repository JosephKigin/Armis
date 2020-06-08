using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ShippingModels
{
    public class ShipViaCodeModel
    {
        public short ShipViaId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public byte ShipViaTypeId { get; set; }
        public byte CarrierId { get; set; }

        public CarrierCodeModel CarrierCode { get; set; }
        public ShipViaTypeCodeModel ShipViaType { get; set; }
    }
}

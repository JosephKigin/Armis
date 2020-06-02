﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ShippingModels
{
    public class ShipViaModel
    {
        public short ShipViaId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public byte ShipViaTypeId { get; set; }
        public byte CarrierId { get; set; }
        public CarrierCodeModel CarrierCodeModel { get; set; }

        //TODO: ShipViaType code might need to be in here.  It might need a model created for it as well.
    }
}
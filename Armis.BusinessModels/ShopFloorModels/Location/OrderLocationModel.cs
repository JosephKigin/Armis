using Armis.BusinessModels.ShippingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ShopFloorModels.Location
{
    public class OrderLocationModel
    {
        public int OrderId { get; set; }
        public byte OrderLine { get; set; }
        public int LocationId { get; set; }
        public short ContainerId { get; set; }

        public ContainerModel Container { get; set; }
        public ShopLocationModel ShopLocation { get; set; }
    }
}

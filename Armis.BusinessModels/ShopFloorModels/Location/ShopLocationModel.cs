using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ShopFloorModels.Location
{
    public class ShopLocationModel
    {
        public int LocationId { get; set; }
        public string LocCode { get; set; }
        public string Description { get; set; }
        public short? AreaId { get; set; }
        public byte LocationTypeId { get; set; }
    }
}

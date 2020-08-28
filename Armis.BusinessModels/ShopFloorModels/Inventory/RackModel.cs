using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ShopFloorModels.Inventory
{
    public class RackModel
    {
        public int RackId { get; set; }
        public string Description { get; set; }
        public string Dimensions { get; set; }
        public int? MaterialAlloyId { get; set; }
        public short? AreaId { get; set; }
        public int? ExtensionQty { get; set; }
        public string Photo { get; set; }
        public string Notes { get; set; }
    }
}

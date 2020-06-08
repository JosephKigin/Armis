using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ShopFloorModels.Area
{
    public class AreaModel
    {
        public short AreaId { get; set; }
        public string Description { get; set; }
        public byte? DeptTypeId { get; set; }
        public bool? AllowLogin { get; set; }
        public int? DefaultLocation { get; set; }


    }
}

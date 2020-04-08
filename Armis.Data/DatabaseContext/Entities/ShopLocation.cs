﻿using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ShopLocation
    {
        public ShopLocation()
        {
            Area = new HashSet<Area>();
            OrderLocation = new HashSet<OrderLocation>();
        }

        public int LocationId { get; set; }
        public string LocCode { get; set; }
        public string Description { get; set; }
        public short? AreaId { get; set; }
        public string LocTypeCd { get; set; }

        public virtual Area AreaNavigation { get; set; }
        public virtual LocationTypeCode LocTypeCdNavigation { get; set; }
        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<OrderLocation> OrderLocation { get; set; }
    }
}
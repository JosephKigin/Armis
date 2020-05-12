using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ShopLocation
    {
        public ShopLocation()
        {
            Area = new HashSet<Area>();
            OrderLocation = new HashSet<OrderLocation>();
            PartTranFromLocationNavigation = new HashSet<PartTran>();
            PartTranToLocationNavigation = new HashSet<PartTran>();
        }

        public int LocationId { get; set; }
        public string LocCode { get; set; }
        public string Description { get; set; }
        public short? AreaId { get; set; }
        public byte LocationTypeId { get; set; }

        public virtual Area AreaNavigation { get; set; }
        public virtual LocationTypeCode LocationType { get; set; }
        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<OrderLocation> OrderLocation { get; set; }
        public virtual ICollection<PartTran> PartTranFromLocationNavigation { get; set; }
        public virtual ICollection<PartTran> PartTranToLocationNavigation { get; set; }
    }
}

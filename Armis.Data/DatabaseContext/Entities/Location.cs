using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Location
    {
        public Location()
        {
            Area = new HashSet<Area>();
            OrderLocation = new HashSet<OrderLocation>();
        }

        public int LocationId { get; set; }
        public string Description { get; set; }
        public short? AreaId { get; set; }
        public string Type { get; set; }

        public virtual Area AreaNavigation { get; set; }
        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<OrderLocation> OrderLocation { get; set; }
    }
}
